    public IEnumerable<Table> GetTables(Func<Table,bool> getValue)
    {
        return a.Table.Where(table => /*some common filter*/)
                      .Where(table => getValue(table))
    }
