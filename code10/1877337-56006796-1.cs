        var history = new List<(int x, int y)>();
        do
        {
            Console.WriteLine("Enter Hit Coordinates (x,y):");
            var input = Console.ReadLine();
            var parts = input.Split(',');
            if (parts.Length!=2)
            {
                Console.WriteLine("Please enter two values separated by a comma.");
                break;
            }
            if (int.TryParse(parts[0].Trim(), out int x) && int.TryParse(parts[1].Trim(), out int y))
            {
                var coords = (x, y);
                if (history.Contains(coords))
                {
                    Console.WriteLine($"Coordinates ({x},{y}) Previously Played.");
                }
                else
                {
                    // use the x, y values below
                    Console.WriteLine($"User input was: ({x},{y})");
                    history.Add(coords);
                }
            }
            else
            {
                Console.WriteLine("Please enter numeric values.");
            }
        }
        while (true);
