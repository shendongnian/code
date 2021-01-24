            string mainconn = @"data source=WS-KIRON-01;initial catalog=TestDatabase;integrated security=True;MultipleActiveResultSets=True";
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "insert into [TestTable] values (@fname,@lname)";
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand(sqlquery, sqlconn);
            cmd.Parameters.AddWithValue("@fname", "TestTableValue");
            cmd.Parameters.AddWithValue("@lname", "TestTableValue2");
            cmd.ExecuteNonQuery();  
            sqlconn.Close();
