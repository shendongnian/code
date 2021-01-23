    static void Main(string[] args)
    {
        List<string> Greetings = new List<string>()
        {
            "Hello",
            "Hi",
            "Hallo"
        };
    
        List<string> Targets = new List<string>()
        {
            "Mate",
            "m8",
            "friend",
            "friends"
        };
    
        var combinations = new List<Tuple<int, int>>();
    
        Random random = new Random();
    
        for (int i = 0; i < 5; i++)
        {
            Tuple<int, int> tmpCombination = new Tuple<int, int>(random.Next(Greetings.Count), random.Next(Targets.Count));
    
            if (!combinations.Contains(tmpCombination))
            {
                combinations.Add(tmpCombination);
            }
        }
    
        foreach (var item in combinations)
        {
            Console.WriteLine("{0} my {1}", Greetings[item.Item1], Targets[item.Item2]);
        }
    
        Console.ReadKey();
    }
