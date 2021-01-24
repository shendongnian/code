    string result = "";
    foreach (string line in Content)
    {
        if (line.StartsWith("\""))
        {
           result = line;
           result = result.Replace("\"", "");
           result = result.Trim();
        }
    }
