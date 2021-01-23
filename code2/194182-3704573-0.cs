    private string replaceMe(System.Text.RegularExpressions.Match m)
    {
        return "donkey[" + m.Index.ToString() + "]";
    }
    private replaceStr() {
        string s = "lionlionlionlionlionlionlionlionlionlion";
        Regex r = new Regex("lion");
        s = r.Replace(s, new System.Text.RegularExpressions.MatchEvaluator(replaceMe),6);
        Console.Out.Write(s);
    }
