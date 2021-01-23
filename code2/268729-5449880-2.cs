    public int GetEmployeeCount()
    {
        return GetQuery().Count();
    }
    public IQueryable BindEmployees(int startRowIndex, int maximumRows)
    {
        var query = from e in GetQuery()
                    select new { /*Do your anonymous type here*/ };
        return query.Skip(startRowIndex).Take(maximumRows);
    } 
