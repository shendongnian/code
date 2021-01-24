    public static string SelectNameFromId(OleDbConnection connection, int id)   
    {
        DataTable data_table = new DataTable();
        OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT Name FROM Student WHERE ID = ?", connection);
        adapter.SelectCommand.Parameters.AddWithValue("p1", id); //positional indexing
        adapter.Fill(data_table);
        string n = data_table.Rows[0]["Name"].ToString();
        return n;
    }
