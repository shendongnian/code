    private DataTable MatcherTable(DataTable table)
    {
        DataTable match = table.Rows.Cast<DataRow>()
                               .GroupBy(x => x["Name"])
                               .Where(g => g.Count() > 1)
                               .Select(k => k.FirstOrDefault())
                               .CopyToDataTable();
        return match;
    }
