    using (OleDbConnection connection = new 
    OleDbConnection(String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"HDR={1};IMEX=1;Readonly=1;Extended Properties=Excel 8.0;\"",pathOnly ,header )))
    {
        using (OleDbCommand command = new OleDbCommand(sql, connection))
        {
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
        }
    }
