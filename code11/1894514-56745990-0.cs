    void DetailMenuInput()
    {
        while (true)
        {
            Console.TreatControlCAsInput = false;
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Backspace)
            {
                if (input.Length > 0)
                    input = input.Remove(input.Length - 1);
                continue;
            }
            input += key.KeyChar.ToString();
        }
    }
