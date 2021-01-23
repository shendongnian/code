    static IEnumerable<int> Get_ExId_List(ICollection<int> lst_TermId)
    {
        //this is just for the example - get the real data instead
        var data = new[] {
            new { Ex_Id = 1, Term_Id = 2},
            new { Ex_Id = 1, Term_Id = 3},
            new { Ex_Id = 1, Term_Id = 4},
            new { Ex_Id = 1, Term_Id = 5},
            new { Ex_Id = 2, Term_Id = 2},
            new { Ex_Id = 3, Term_Id = 2},
            new { Ex_Id = 3, Term_Id = 4},
        };
        return data
            .Where(row => lst_TermId.Contains(row.Term_Id))
            .GroupBy(row => row.Ex_Id)
            .Where(group => group.Count() == lst_TermId.Count())
            .Select(group => group.Key);
    }
    static void Main(string[] args)
    {
        HashSet<int> lst_TermId = new HashSet<int>();
        lst_TermId.Add(2);
        Console.WriteLine();
        var result = Get_ExId_List(lst_TermId);
        foreach (var exid in result)
            Console.WriteLine(exid);
        lst_TermId.Add(4);
        Console.WriteLine();
        result = Get_ExId_List(lst_TermId);
        foreach (var exid in result)
            Console.WriteLine(exid);
        lst_TermId.Add(3);
        Console.WriteLine();
        result = Get_ExId_List(lst_TermId);
        foreach (var exid in result)
            Console.WriteLine(exid);
    }
