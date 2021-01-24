    using (SqlConnection con = new SqlConnection("YOUR CONNECTION STRING"))
    {
        string query = "SELECT custNeed, isActive FROM Customers WHERE ID = 1000001;";
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read(); //reads the first single returned row. 
                checkBox1.Checked = (bool)reader["custNeed"];
                checkBox2.Checked = (bool)reader["isActive"];
            }
        }
    }
