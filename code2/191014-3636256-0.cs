       using (SqlConnection connection1 = new SqlConnection(connectionString1),
              connection2 = new SqlConnection(connectionString2),
              connection3 = new SqlConnection(connectionString3))
       {
           connection1.Open();
           //...
           connection2.Open();
           //...
           connection3.Open();
       }
