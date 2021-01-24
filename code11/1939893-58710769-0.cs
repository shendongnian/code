    IList<string> items = GetDbItems("a", "b", "c");
    if (items.Any())
    {
        control.Items.Clear();
        control.Items.Add(items);
    }
    private IList<string> GetDbItems(string select, string from, string order = "")
    {
            var result = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (order == "") order = select;
                using (SqlCommand command = new SqlCommand("SELECT " + select +
                    " FROM " + from + " ORDER BY " + order, conn))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result.Add(dataReader[select]);
                    }
                }
            }
            return result;
        }
