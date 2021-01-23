     SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand(@"SELECT * FROM compsTickers", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                tickerList.Add(reader.GetString(0));
               
            }
            reader.Close();
            con.Close();
