    public static string[] SplitCsv(string line)
    {
        List<string> result = new List<string>();
        var currentStr = "";
        bool inQuotes = false;
        for (int i = 0; i < line.Length; i++)
        {
            if (inQuotes)
            {
                if (line[i] == '\"')
                    inQuotes = false;
                else
                    currentStr += line[i];
            }
            else
            {
                if (line[i] == '\"')
                    inQuotes = true;
                else if (line[i] == ',')
                {
                    result.Add(currentStr);
                    currentStr = "";
                }
                else
                    currentStr += line[i];
            }
        }
        return result.ToArray();
    }
