        public static class DataAccess
        {
            private static string reportConnectionString = "Data Source=;Initial Catalog=;Persist Security Info=;User ID=;Password=";
    
        public static class Answer
        {
           public int AnswerID {get; set;}
           public string Answer {get; set;}
        }
        
            public static bool GetRecords(int AnswerId, out List<Answer> lstAnswers, out string sMessage)
            {
                lstAnswers = new List <Answer>();
                AnswerID;
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
                                    Answer answer= new Answer();
        
                                    answer.answer_id= reader.GetInt32(reader.GetOrdinal("answer_id"));
                                    answer.answer= reader.GetValue(reader.GetOrdinal("answer")).ToString();
                                    
                                    // -- Adding single object to list 
                                    lstAnswers.Add(log);
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
