    static void Main(string[] args)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        dic.Add(1, 1);
        dic.Add(2, 4);
        dic.Add(3, 1);
        dic.Add(4, 2);
        var result = from p in dic
                     group p by p.Value into g
                     where g.Count() > 1
                     select g;
        foreach (var r in result)
        { 
            var sameValue = (from p in r 
                            select p.Key + "").ToArray();
           
            Console.WriteLine("{0} has the same value {1}:" , string.Join("," , sameValue) , r.Key);
        }
        Console.ReadKey();
    }
