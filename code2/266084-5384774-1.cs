Take advantage of the fact that Where can have any function taking type Table as a parameter and returning a boolean to create a function like:
    public IQueryable<Table> QueryTables(Func<Table, bool> testFunction)
    {
        return a.Table.Where(testFunction).AsQueryable<Table>();
    }
