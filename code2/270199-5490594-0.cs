        SqlConnection conn = new SqlConnection(actual_string);
    conn.Open();
    
    // Create the command string
    SqlCommand cmd = new SqlCommand("EXEC insert_test @var1, @var2, @var3, @str1, @str2", conn);
    
    // Iterate through all of the objects
    try {
        for (int i = 0; i < 10000; i++) {
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@var1", var1));
            cmd.Parameters.Add(new SqlParameter("@var2", var2));
            cmd.Parameters.Add(new SqlParameter("@var3", var3));
            cmd.Parameters.Add(new SqlParameter("@str1", str1));
            cmd.Parameters.Add(new SqlParameter("@str2", str2));
    
            // Read in all the data
            cmd.ExecuteNonQuery();
        }
    } finally {
        conn.Close();
    }
