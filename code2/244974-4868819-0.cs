    static void Main(string[] args)
    {
        Dictionary<string, float> groups = new Dictionary<string, float>();
        groups.Add("Group1", 10);
        groups.Add("Group2", 15);
        groups.Add("Group3", 20);
        groups.Add("Group4", 30);
        for (int i=0; i < groups.Count - 1; i++)
        {
            Iterate(groups, i, 0, "");
        }
        Console.Read();
    }
    private static void Iterate(Dictionary<string, float> groups, int k, float sum, string s)
    {
        KeyValuePair<string, float> g = groups.ElementAt(k);
        if (string.IsNullOrEmpty(s))
        {
            s = g.Key;
        }
        else
        {
            s += " + " + g.Key;
            Console.WriteLine(s + " = " + (sum + g.Value));
        }
        for (int i = k + 1; i < groups.Count; i++)
        {
            Iterate(groups, i, sum + g.Value, s);
        }
    }
