    public static Dictionary<string, string> ParseArgs(string[] args)
    {
         Dictionary<string, string> results = new Dictionary<string, string>();
         foreach (string arg in args)
         {
              string[] parts = arg.Split('=');
              if (parts.Length > 1)
              {
                   results[parts[0]] = parts[1];
                   continue;
              }
              else
              {
                   results[arg] = arg; // assuming arg string in args won't repeat, meaning its unique. Otherwise please use ContaineKey if condition before adding or over-writing.
               }
         }
         return results;
    }
