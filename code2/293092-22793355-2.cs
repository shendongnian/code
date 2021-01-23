    public static double[][] readWhitespaceDelimitedDoubles(string[] input)
    {
        double[][] array = input.Where(line => !String.IsNullOrWhiteSpace(line)) // Use this to filter blank lines.
            .Select(line => line.Split((string[])null, StringSplitOptions.RemoveEmptyEntries))
            .Select(line => line.Select(element => double.Parse(element)))
            .Select(line => line.ToArray())
            .ToArray();
            return array;
    }
