    static void Main(string[] args)
    {
        List<Discount> list = new List<Discount>();
        list.Add(new Discount { Id = 1, Title = "Adam" });
        list.Add(new Discount { Id = 2, Title = "Ben" });
        list.Add(new Discount { Id = 3, Title = "Alex" });
        list.Add(new Discount { Id = 4, Title = "Daniel" });
        list.Add(new Discount { Id = 5, Title = "Ethan" });
        list.Add(new Discount { Id = 6, Title = "Howard" });
        list.Add(new Discount { Id = 7, Title = "Peter" });
        list.Add(new Discount { Id = 8, Title = "Tazz" });
        list.Add(new Discount { Id = 9, Title = "Steve" });
        list.Add(new Discount { Id = 10, Title = "Lyle" });
        Dictionary<string, List<Discount>> dic = new Dictionary<string, List<Discount>>();
        foreach (Discount d in list)
        {
            string range = GetRange(d.Title);
            if (dic.ContainsKey(range))
                dic[range].Add(d);
            else
                dic.Add(range, new List<Discount> { d });
        }
    }
    static string GetRange(string s)
    {
        char c = s.ToLower()[0];
        if (c >= 'a' && c <= 'd')
            return "A - D";
        else if (c >= 'e' && c <= 'h')
            return "E - H";
        else if (c >= 'i' && c <= 'l')
            return "I - L";
        else if (c >= 'm' && c <= 'p')
            return "M - P";
        else if (c >= 'q' && c <= 't')
            return "Q - T";
        else if (c >= 'u' && c <= 'z')
            return "U - Z";
        return "";
    }
