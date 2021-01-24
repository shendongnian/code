    public static void Main(string[] args)
      {
        string pattern = "\\/(.*?)\\/(.+)";
        string text = "/19/Ora01";
        Match match = Regex.Match(text, pattern);
        string first = match.Groups[1].Value;
        string second = match.Groups[2].Value;
    
        Console.WriteLine(first);
        Console.WriteLine(second);
    
        Console.ReadLine();
      }
