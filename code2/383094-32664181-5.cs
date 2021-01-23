    private string ShortenPath(string path, int maxLength)
    {
        int pathLength = path.Length;
        string[] parts;
        parts = label1.Text.Split('\\');
        int startIndex = (parts.Length - 1) / 2;
        int index = startIndex;
        string output = "";
        output = String.Join("\\", parts, 0, parts.Length);
        decimal step = 0;
        int lean = 1;
        do
        {
            parts[index] = "...";
            output = String.Join("\\", parts, 0, parts.Length);
            step = step + 0.5M;
            lean = lean * -1;
            index = startIndex + ((int)step * lean);
        }
        while (output.Length >= maxLength && index != -1);
        return output;
    }
