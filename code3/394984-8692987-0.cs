    SqlCommand cmd = new SqlCommand("SELECT MIN(column_name) FROM table_name", conn);
        try
        {
            conn.Open();
            int quizid = (Int32)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
