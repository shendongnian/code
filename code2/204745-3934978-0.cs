    [STAThread]
    static void Main()
    {
        string pat = @"ENGL101_.*_(.*)";
        Regex r = new Regex(pat, RegexOptions.IgnoreCase);
    
        Console.WriteLine(r.IsMatch(@"ENGL101_BELIEVE_WRIGHTSTONE.docx"));
        Console.WriteLine(r.IsMatch(@"Engl101_ThisIBelieve_Williams.docx"));
    }
    
