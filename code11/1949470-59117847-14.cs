    static void Main(string[] args)
    {
        do {
            PlayGame();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Would you play to play again? Y or N");
        } while (Console.ReadLine().ToLower() == "y");
    }
