    public DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            new string[] { "Column 1", "Column 2", "Column 3", "Column 4", "Column 5", "Column 6" }
                .ToList()
                .ForEach(c => { dt.Columns.Add(new DataColumn(c)); });
            return dt;
        }
