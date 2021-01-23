    private string ShortenPath(string path, int maxLength)
    {
        int pathLength = path.Length;
        string[] parts;
        parts = path.Split('\\');
        int startIndex = (parts.Length - 1) / 2;
        int index = startIndex;
        String output = "";
        output = String.Join("\\", parts, 0, parts.Length);
        decimal step = 0;
        int lean = 1;
        while (output.Length >= maxLength && index != 0 && index != -1)
        {
            parts[index] = "...";
            output = String.Join("\\", parts, 0, parts.Length);
            step = step + 0.5M;
            lean = lean * -1;
            index = startIndex + ((int)step * lean);
        }
        // result can be longer than maxLength
        return output.Substring(0, Math.Min(maxLength, output.Length));  
    }
