    public static DataTable cols(this DataTable table, string[] names, Type[] types)
    {
        for(...)
        {
            table.Columns.Add(names[i], types[i]); 
        }
        return table;
    }
    .cols(new string[] {"col1", "col2"}, new Type[] {typeof(int), typeof(string)})
