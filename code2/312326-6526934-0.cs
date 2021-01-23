    string connectionString = "<yourconnectionstringhere>";
    using (SqlConnection connection = new SqlConnection(connectionString)) {
        try {
            connection.Open();
        }
        catch (System.Data.SqlClient.SqlException ex) {
            // handle
            return;
        }
        string selectCommandText = "SELECT * FROM <yourtable>";
        using (SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, connection)) {
            using (DataTable table = new DataTable("<yourtable>")) {
                adapter.Fill(table);
                StringBuilder commaDelimitedText = new StringBuilder();
                commaDelimitedText.AppendLine("col1,col2,col3"); // optional if you want column names in first row
                foreach (DataRow row in table.Rows) {
                    string value = string.Format("{0},{1},{2}", row[0], row[1], row[2]); // how you format is up to you (spaces, tabs, delimiter, etc)
                    commaDelimitedText.AppendLine(value);
                }
                File.WriteAllText("<pathhere>", commaDelimitedText.ToString());
            }
        }
    }
