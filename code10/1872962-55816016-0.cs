    while (true)
    {
        Console.WriteLine("Please enter a word for the sum of it's ASCII value !!!");
        Console.WriteLine("Type the word 'exit' at any time to escape ...");
        string word = Console.ReadLine();
        if (word.Equals("exit", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }
        int sum = 0;
        foreach (char c in word)
        {
            sum += c;
        }
        Console.WriteLine(sum);
    }
