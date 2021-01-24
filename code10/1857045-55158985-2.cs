    public IEnumerable<string> FindDuplicateSymbolNumber(DataTable dt) 
    {
        return from c in dt.AsEnumerable()
               group 1 by c.Field<string>("SYMBOL_NO") into g
               where g.Skip(1).Any()
               select g.Key.RowId;
    }
