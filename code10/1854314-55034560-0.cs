    private static int playerCounter = 0;
    private static string[] players = { "John", "Mary", "Randy", "Martha" };
    private static string GetNextPlayer()
    {
        return players[playerCounter++ % players.Length];
    }
    private static void Main(string[] args)
    {
        while (true)
        {
            var player = GetNextPlayer();
            Console.WriteLine($"Current player is: {player}");
            Console.Write("Press any key to move to the next player...");
            Console.ReadKey();
            Console.WriteLine('\n');
        }
    }
