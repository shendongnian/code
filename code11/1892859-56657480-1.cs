    public int AddQuestionOrientation(Question questionForAdd)
    		{
    			try
    			{
    				using (SqlConnection con = new SqlConnection(connectionString))
    				{
    					con.Open();
    					using (SqlCommand command = new SqlCommand("Question_Insert"))
    					{
    						command.CommandType = CommandType.StoredProcedure;
    
    						command.Parameters.Add("@Libelle", SqlDbType.VarChar, 50).Value = questionForAdd.Libelle;
    						command.Parameters.Add("@Bareme", SqlDbType.VarChar, 50).Value = questionForAdd.Bareme;
    						command.Parameters.Add("@Filliere", SqlDbType.VarChar, 50).Value = questionForAdd.IdFiliere;
    						command.Parameters.Add("@QuestionID", SqlDbType.Int).Direction = ParameterDirection.Output;
    						command.ExecuteNonQuery();
    						return int.Parse(command.Parameters["@QuestionID"].Value.ToString());
    					}
    				}
    			}
    			catch (Exception ex)
    			{
    				return 0;
    			}
    		}
