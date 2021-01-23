    public static string ApplicationArguments()
    {
        List<string> args = Environment.GetCommandLineArgs().ToList();
        args.RemoveAt(0); // remove executable
        StringBuilder sb = new StringBuilder();
        foreach (string s in args)
        {
            // todo: add escape double quotes here
            sb.Append(string.Format("\"{0}\" ", s)); // wrap all args in quotes
        }
        return sb.ToString().Trim();
    }
