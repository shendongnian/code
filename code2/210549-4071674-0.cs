    public static DataTable col<T1>(this DataTable table, string name1)
    {
        table.Columns.Add(name1, typeof(T1));
        return table;
    }
    
    public static DataTable col<T1, T2>(this DataTable table, string name1, string name2)
    {
        table.Columns.Add(name1, typeof(T1));
        table.Columns.Add(name2, typeof(T2));
        return table;
    }
    
    public static DataTable col<T1, T2, T3>(this DataTable table, string name1, string name2, string name 3)
    {
        table.Columns.Add(name1, typeof(T1));
        table.Columns.Add(name2, typeof(T2));
        table.Columns.Add(name3, typeof(T3));
        return table;
    }
