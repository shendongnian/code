    var array = File.ReadAllLines(filename)
                    .Select(line => line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    .Where(line => !string.IsNullOrWhiteSpace(line)) // Use this to filter blank lines.
                    .Select(int.Parse) // Assuming you want an int array.
                    .ToArray();
