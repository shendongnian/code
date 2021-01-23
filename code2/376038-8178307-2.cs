    private void SetFiltring(ref DataTable table)
    {
        table = table.AsEnumerable()
                     .AsQueryable()
                     .Where("it["Date"].ToString().ToUpper().Contains("21".ToUpper()))")
                     .CopyToDataTable();
    }
