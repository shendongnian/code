    public static void DeleteLastLine(string filepath)
    {
        List<string> lines = File.ReadAllLines(filepath).ToList();
        File.WriteAllLines(filepath, lines.GetRange(0, lines.Count - 1).ToArray());
    }
