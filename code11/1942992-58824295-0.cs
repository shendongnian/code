    int ReadInteger(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            var response = Console.ReadLine();
            int result;
            if (int.TryParse(response, out result)) return result;
        }
    }
