    const string FoundCardMessage = "You found a {0} card";
    private static void Main(string[] args)
    {
        var cardTypes = new List<string> {"Common", "Rare", "Legendary"};
        foreach (var cardType in cardTypes)
        {
            var message = string.Format(FoundCardMessage, cardType);
            Console.WriteLine(message);
        }
    }
