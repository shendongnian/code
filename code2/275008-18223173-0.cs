            List<int> s = new List<int>();
            conn.Open();
            SqlCommand command2 = conn.CreateCommand();
            command2.CommandText = ("select turn from Vehicle where Pagged='YES'");
            command2.CommandType = CommandType.Text;
            SqlDataReader reader4 = command2.ExecuteReader();
            while (reader4.Read())
            {
                s.Add(Convert.ToInt32((reader4["turn"]).ToString()));
            }
            conn.Close();
