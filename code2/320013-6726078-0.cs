    public static void NumericalSort(List<string> l)
    {
        Regex rgx = new Regex("([^0-9]*)([0-9]+)");
        l.Sort((a, b) =>
        {
            var ma = rgx.Matches(a);
            var mb = rgx.Matches(b);
            for (int i = 0; i < ma.Count; ++i)
            {
                int ret = ma[i].Groups[1].Value.CompareTo(mb[i].Groups[1].Value);
                if (ret != 0)
                    return ret;
                ret = int.Parse(ma[i].Groups[2].Value) - int.Parse(mb[i].Groups[2].Value);
                if (ret != 0)
                    return ret;
            }
            return 0;
        });
    }
    static void Main(string[] args)
    {
        List<string> l = new string[] { "1", "2a", "2b", "6", "8a", "10a" }.ToList();
        NumericalSort(l);
        foreach (var item in l)
            Console.WriteLine(item);
    }
