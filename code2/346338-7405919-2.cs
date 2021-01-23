    private bool BackupTable(string connectionString, string tableName, string directory) {
        using (SqlConnection connection = new SqlConnection(connectionString)) {
            try {
                connection.Open();
            }
            catch (System.Data.SqlClient.SqlException ex) {
                // Handle
                return false;
            }
            using (SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT * FROM {0}", tableName), connection)) {
                using (DataTable table = new DataTable(tableName)) {
                    adapter.Fill(table);
                    try {
                        table.WriteXml(Path.Combine(directory, string.Format("{0}.xml", tableName)));
                        table.WriteXmlSchema(Path.Combine(directory, string.Format("{0}.xsd", tableName)));
                    }
                    catch (System.UnauthorizedAccessException ex) {
                        // Handle
                        return false;
                    }
                }
            }
        }
        return true;
    }
