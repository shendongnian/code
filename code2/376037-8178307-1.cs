    private void SetFiltring(ref DataTable table)
    {
        var t = table.AsEnumerable()
                     .AsQueryable()
                     .Where("it["Date"].ToString().ToUpper().Contains("21".ToUpper()))");
        ...
    }
