    string input = "book";
    for (int i = 1; i < input.Length; i++)
    {
        Console.WriteLine(string.Concat(input[0], input[i]));
    }
