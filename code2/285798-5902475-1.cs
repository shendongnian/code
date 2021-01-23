    public DataTable List(EmployeeFilter filter, string sortType, int startRowIndex, int maximumRows)
    {
        var rows = listQuery();
        if (!string.IsNullOrEmpty(sortType)) rows = listSort(rows, sortType).Skip(startRowIndex);
        if (maximumRows > 0) rows = rows.Take(maximumRows);
        DataTable dt = rows.ToTable(r => new object[] { rows });
        return dt;
    }
