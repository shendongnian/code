    public static void InsertAndSubmit<T>(this System.Data.Linq.Table<T> tbl, T element)
        where T : class
    {
        tbl.InsertOnSubmit(element);
        tbl.Context.SubmitChanges();
    }
