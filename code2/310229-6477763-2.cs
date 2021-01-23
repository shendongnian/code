    using (SqlCeConnection conn = new SqlCeConnection(connString))
    {
        string sqlStr = @"INSERT INTO FooTable (FooName) VALUES (@FooName)";
        using (SqlCeCommand cmd = new SqlCeCommand(sqlStr, conn))
        {
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@FooName", 'someString');
                cmd.ExecuteNonQuery();
    
                conn.Close();
            }
            catch (SqlCeException se)
            {
                MessageBox.Show(se.ToString());
            }
        }
    }
