    public static void NumericalSort(string[] ar)
    {
        Regex rgx = new Regex("([^0-9]*)([0-9]+)");
        Array.Sort(ar, (a, b) =>
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
        string[] ar = new string[] { "a99.txt", "b98.txt", "b100.txt" };
        NumericalSort(ar);
        foreach (var a in ar)
            Console.WriteLine(a);
    }
