    void ProcessFile()
    {
        var file_path = @"Tags.txt";
        var sb = new StringBuilder();
        foreach (var line in File.ReadLines(file_path))
        {
            if (!Regex.IsMatch(line, @"^Line\s+[0-9]+:"))
            {
                sb.AppendLine(line);
            }
        }
        // Save back
        File.WriteAllText(file_path, sb.ToString());
    }
