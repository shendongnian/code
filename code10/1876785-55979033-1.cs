    public static List<string> Tokinization(string stringy)
    {
        List<string> terms = new List<string>();
        foreach (string ss in stringy.Split(new string[] { " ", ",", ".", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
        {
            terms.Add(ss);
        }
        return terms;
    }
