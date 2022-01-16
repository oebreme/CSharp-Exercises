using System;

namespace number_guessing_game
{
    public class NumberGuessingGame
    {
        public static void Main()
        {
            numberGuessingGame();
        }

        public static void numberGuessingGame() {

            Int16 tries = 13;
            Int16 maxSize = 100;
            Random random = new Random();
            int numberToBeGuessed = random.Next() % maxSize + 1;
            int userGuess = 0;
            bool gameIsWon = false;

            printIntro();

            gameStart();


            while (!gameIsWon && tries > 0)
            {
                Console.Write("\nGib eine Zahl ein: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                userGuess = getUserNumberInput();
                Console.ForegroundColor = ConsoleColor.DarkGray;

                if (userGuess > numberToBeGuessed)
                {
                    Console.Write("Deine Zahl " + userGuess + " war zu hoch.");
                    tries--;
                    outputTries(tries);
                }
                else if (userGuess < numberToBeGuessed)
                {
                    Console.Write("Deine Zahl " + userGuess + " war zu niedrig.");
                    tries--;
                    outputTries(tries);
                }
                else if (userGuess == numberToBeGuessed)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Deine Zahl " + userGuess + " war korrekt." + "\nDu hast gewonnen!");
                    Console.ReadLine();
                    gameIsWon = true;
                }
            }

            if (tries == 0)
            {
                Console.WriteLine("Du hast keine Versuche mehr übrig!");
            }

            restartGame();


        }

        private static void restartGame()
        {
            Console.WriteLine("Moechtest du noch einmal spielen? (Y/N)");
            String userInput = getUserTextInput().ToUpper();
            if (userInput.Contains("Y"))
            {
                Console.Clear();
                numberGuessingGame();
            }
            else
            {
                Console.Write("Beende ");
                waitingDots();
            }
        }

        private static String getUserTextInput()
        {
            String userInput = Console.ReadLine();
            return userInput;
        }

        private static void gameStart()
        {
            Console.WriteLine("\n\tRate eine Zahl zwischen  1  und  100");
            Console.Write("\n\nDrücke ENTER um zu starten ");
            Console.ReadKey();
            waitingDots();
        }

        private static void outputTries(Int16 tries)
        {
            Console.Write(" Du hast noch " + tries + " Versuche übrig");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\n");
        }

        private static int getUserNumberInput()
        {
            try
            {
                int userInput = int.Parse(Console.ReadLine());
                return userInput;
            }
            catch (Exception)
            {
                throw new Exception("Eingabe konnte nicht geparsed werden");
            }
        }

        private static void printIntro()
        {
            Console.Write("\n" +
            "\t   _  __           __           _____               \n" +
            "\t  / |/ /_ ____ _  / /  ___ ____/ ___/_ _____ ___ ___\n" +
            "\t /    / // /  ' \\/ _ \\/ -_) __/ (_ / // / -_|_-<(_-<\n" +
            "\t/_/|_/\\_,_/_/_/_/_.__/\\__/_/  \\___/\\_,_/\\__/___/___/\n");
        }

        private static void waitingDots()
        {
            Console.Write("\n");
            Console.Write(".");
            System.Threading.Thread.Sleep(250);
            Console.Write(".");
            System.Threading.Thread.Sleep(250);
            Console.Write(".");
            System.Threading.Thread.Sleep(250);
            Console.Write("\n");
        }
    }
}