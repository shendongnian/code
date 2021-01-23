    // I'm assuming you're using .NET 4
    var lines = File.ReadLines(filename);
    var components = new List<string>();
    StringBuilder builder = null;
    foreach (var line in lines)
    {
        if (line.StartsWith("Component: "))
        {
            if (builder != null)
            {
                components.Add(builder.ToString());
            }
            builder = new StringBuilder();
        }
        builder.Append(line);
        builder.Append("\r\n");
    }
    // Get the trailing component
    if (builder != null)
    {
        components.Add(builder.ToString());
    }
