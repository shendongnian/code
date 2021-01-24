    public static void ReNumberLines(string filePath)
    {
        if (!File.Exists(filePath)) throw new FileNotFoundException(nameof(filePath));
        var lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            var num = i + 1;
            var parts = lines[i].Split(new[] {')'}, 2);  // Split on the first ')'
            // If there was no ')' character, add a line number to this line
            if (parts.Length == 1)
            {
                lines[i] = $"{num}) {parts[0].Trim()}";
                continue;
            }
            // Try to determine if we need to modify the beginning of the line.
            // If it starts with non-numeric characters, add '#)'
            // Otherwise if the number doesn't match, replace it with the correct #
            int number;
            if (int.TryParse(parts[0].Trim(), out number))
            {
                // There was a number before the ')', so if it matches we can continue
                if (number == num) continue;
                // Otherwise replace it with the correct number
                lines[i] = $"{num}) {parts[1].Trim()}";
            }
            else
            {
                // The characters before the ')' are not numeric, so we have to assume that
                // user content is here and prefix this line with the correct number and ')'
                lines[i] = $"{num}) {parts[0]}){parts[1]}";
            }
        }
        File.WriteAllLines(filePath, lines);
    }
