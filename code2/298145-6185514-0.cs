    static void Main()
    {
        string s = "hello<I NEED <I NEED THIS TEXT> THIS TEXT>goodbye";
            
        string r = Regex.Match(s, "<(.*)>").Groups[1].Value;
        int start = s.IndexOf("<") + 1;
        int end = s.IndexOf(">", start);
        string t = s.Substring(start, end - start);
        Console.WriteLine(r);
        Console.WriteLine(t);
        Console.ReadKey();
    }
