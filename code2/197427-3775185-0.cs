    var conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=NWIND.mdb";
    using (var con = new OleDbConnection(conStr))
    {
        con.Open();
        using (var cmd = new OleDbCommand("select * from Suppliers", con))
        using (var reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
        {
            var table = reader.GetSchemaTable();
            var nameCol = table.Columns["ColumnName"];
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine(row[nameCol]);
            }
        }
    }
