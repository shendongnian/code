      dr = cmd.ExecuteReader();  
              while (dr.Read())
              {
                  int ids = Int32.Parse(dr["QuestionID"].ToString());
                  SqlCommand sqlCmd = new SqlCommand("INSERT INTO Answers (QuestionId,Answer) Select c.QnId, c.Answer From TempAns c Where c.Id = " + ids + " ");
                  sqlCmd.ExecuteNonQuery(); //this line
              }
              dr.Close();
