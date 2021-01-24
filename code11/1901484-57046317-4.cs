    public static List<Model> GetModels(string filePath)
    {
        return File?
            .ReadAllLines(filePath)
            .Where(line => line.Contains(':'))
            .Select(line => line.Split(':'))
            .Select(lineParts => new Model { Name = lineParts[0], Price = lineParts[1] })
            .ToList();
    }
