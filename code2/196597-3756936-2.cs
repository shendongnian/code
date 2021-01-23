    using (var conn = new SqlConnection())
    {        
         using (var cmd = new SqlCommand(conn))
         {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertCustomer";
            foreach (Customer c in foo)
            {
                 cmd.Parameters.Clear();
                 cmd.Parameters.Add(new SqlParameter("@CustomerName", c.Name);
                 conn.Open(dbConnString);
                 cmd.ExecuteNonQuery();
                 conn.Close();
            }
        }
    }
