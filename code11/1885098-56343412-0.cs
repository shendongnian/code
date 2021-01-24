    private void TypesByMonthRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        List<Source> typesByMonth = new List<String>();
        string CS = ConfigurationManager.ConnectionStrings["U04i5a"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(CS))
        {
            con.Open();
            //string query = "SELECT DISTINCT type, COUNT(type) FROM appointment WHERE (start > @start && end < @end) GROUP BY type;";
            string query = "SELECT DISTINCT type FROM appointment;";
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            typesByMonth.Add(new Source(reader["type"].ToString()));
                        }
                    }
                }
            }
        }
        ReportsDataGridView.DataSource = typesByMonth;
    }
