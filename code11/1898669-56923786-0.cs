    static string Transform(string input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        var builder = new StringBuilder();
        var lines = input.Split(new [] { Environment.NewLine }, StringSplitOptions.None);
        foreach (var line in lines)
        {
            builder.AppendLine(line);
            var items = line.Split('|');
            foreach (var item in items)
            {
                builder.AppendLine(item.Trim());
            }
        }
        return builder.ToString();
    }
