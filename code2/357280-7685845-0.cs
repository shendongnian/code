    void Main()
    {
        string[] letters = new[] { "x", "y", "z" };
        for (int index = 0; index < 10; index++)
        {
            Console.WriteLine((index + 1) + ":" + letters[index % 3]);
        }
    }
