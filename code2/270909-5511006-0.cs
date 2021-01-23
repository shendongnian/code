    public static string BuildCommandLineArgs(List<string> argsList)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (string arg in argsList)
        {
            sb.Append("\"\"" + arg.Replace("\"", @"\" + "\"") + "\"\" ");
        }
        if (sb.Length > 0)
        {
            sb = sb.Remove(sb.Length - 1, 1);
        }
        return sb.ToString();
    }
