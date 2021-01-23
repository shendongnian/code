    private static void Main(string[] args)
    {
       Regex cmdRegEx = new Regex(@"/(?<name>.+?):(?<val>.+)");
       Dictionary<string, string> cmdArgs = new Dictionary<string, string>();
       foreach (string s in args)
       {
          Match m = cmdRegEx.Match(s);
          if (m.Success)
          {
             cmdArgs.Add(m.Groups[1].Value, m.Groups[2].Value);
          }
       }
    }
