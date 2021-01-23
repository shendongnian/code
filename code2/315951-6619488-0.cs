    static void Main(string[] args)
    {
        var dt = new DataTable
        {
            Columns = { { "Lastname",typeof(string) }, { "Firstname",typeof(string) } }
        };
        dt.Rows.Add("Lennon", "John");
        dt.Rows.Add("McCartney", "Paul");
        dt.Rows.Add("Harrison", "George");
        dt.Rows.Add("Starr", "Ringo");
        
        List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
    
        foreach(string e in s)
            Console.WriteLine(e);
    
        Console.ReadLine();
    }
