    public async DataTable GetDataTable()
    {
        var dataTable = new DataTable("Students");
        using (var conn = await DbContext.GetConnection())
        {
            var da = new SQLiteDataAdapter(GET_ALL_QUERY, conn);
            da.Fill(dataTable);
            conn.Close();
        }
        return dataTable;
    }
