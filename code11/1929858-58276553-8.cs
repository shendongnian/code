        public static class DataAccess
        {
            private static string reportConnectionString = "Data Source=;Initial Catalog=;Persist Security Info=;User ID=;Password=";
        
            public static bool GetRecords(int AnswerId, out List<AnswerID> lstAnswerIds, out string sMessage)
            {
                lstAnswerIds = new List <AnswerID>();
                sMessage = "";
                
                try
                {
                    using(SqlConnection connection = new SqlConnection(reportConnectionString))
                    {
                        connection.Open();
        
                        using (SqlCommand command = connection.CreateCommand())
                        {
    command.CommandType = System.Data.CommandType.Text;
                            command.Parameters.AddWithValue("@id", AnswerID);
        
                            command.CommandText = @"select answer_id, answer from answers where answer_id = @id";
        
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows == false)
                                {
                                    sMessage = "Could not find data";
                                    return false;
                                }
                                while(reader.Read())
                                {
                                    AnswerID answer= new AnswerID();
        
                                    answer.answer_id= reader.GetValue(reader.GetOrdinal("answer_id")).ToString();
                                    answer.answer= reader.GetValue(reader.GetOrdinal("answer")).ToString();
                                    
                                    // -- Adding single object to list 
                                    lstLog.Add(log);
                                }
                            }
                        }
                    }
                    return true;
                }
                catch (Exception exc)
                {
                    sMessage = exc.ToString();
                    return false;
                }
            }
        }
