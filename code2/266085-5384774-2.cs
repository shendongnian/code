    using System.Reflection;
    public IQueryable<Table> QueryTables(PropertyInfo pi)
    {
        return a.Table.Where(t => (bool)(pi.GetGetMethod().Invoke(t, null))).AsQueryable<Table>();
    }
To construct the PropertyInfo object, use something like:
    PropertyInfo pi = typeof(Table).GetProperty("Owner");
