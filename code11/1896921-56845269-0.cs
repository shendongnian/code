     private static int GetIntFromInput()
        {
            while (true)
            {
                string value = Console.ReadLine();
                if (!int.TryParse(value, out int parsedInt))
                {
                    Console.WriteLine("Invalid integer! Retry or Ctrl+C to abort program...");
                    continue;
                }
                return parsedInt;
            }
        }
