          SqlConnection conn1 = new SqlConnection("Server=ILLUMINATI;" + "Database=DB;Integrated Security= true");
          SqlCommand COMM = new SqlCommand("select Role from Login where User_Name='admin'", conn1);
          conn1.Open();
          SqlDataReader reader = COMM.ExecuteReader();
          string s = String.Empty;
          while (reader.Read())
              s = reader["Role"].ToString();
          
