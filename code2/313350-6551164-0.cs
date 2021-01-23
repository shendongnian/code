    // this connectionstring can also be an absolute file path
    string connectionString = "Data Source=|DataDirectory|\mydatabase.sdf";
    using (SqlCeConnection connection = new SqlCeConnection(connectionString)) {
        try {
            connection.Open();
        } 
        catch (SqlCeException) {
            // connection failed
        }
        using (SqlCeDataAdapter adapter = new SqlCeDataAdapter("SELECT * FROM <table>", connection)) {
            using (DataTable table = new DataTable("<table>")) {
                adapter.Fill(); // Populate the table with your select statement
                // do stuff with the datatable
                // example:
                foreach (DataRow row in table.Rows) {
                    row["mycolumn"] = "somedata";
                }
                table.AcceptChanges();
            }
        }
    }
