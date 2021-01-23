    int quizID = -1;
    
         using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
        
                    string cmdText = "SELECT MIN(column_name) FROM table_name";
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                quizID = reader.GetInt32("columnname");
                            }
                        }
                        reader.Close();
                    }           
                    conn.Close();
                }
