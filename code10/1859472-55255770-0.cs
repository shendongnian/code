        using (OleDbConnection connection = new 
    OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly + ";Extended Properties=\"Text;HDR=" + header + ";Readonly=0;Extended Properties=Excel 8.0;\""))
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
