    public static List<Test> GetTests(string testVariable)
    {
        DataTable result = new DataTable();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString))
        {
            connection.Open();
            GetQuery(
                connection,
                QueryGetTests,
                ref result,
                new List<SqlParameter>()
                {
                    new SqlParameter("@testVariable", testVariable)
                }
            );
            return result.Rows.OfType<DataRow>().Select(DataRowToTest).ToList();
        }
    }
    private static void GetQuery(SqlConnection connection, string query, ref DataTable dataTable, List<SqlParameter> parameters = null)
    {
        dataTable = new DataTable();
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.CommandTimeout = 120;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            using (SqlDataAdapter reader = new SqlDataAdapter(command))
            {
                reader.Fill(dataTable);
            }
        }
    }
