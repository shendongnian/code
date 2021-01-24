    private void SelectLast()
            {
       
                string sqlLast = "SELECT TOP(1) RecordId FROM [YourtableName] ORDER BY 1 DESC";
    
                Connection.Open();
                using (SqlCommand cmd = new SqlCommand(sqlLast, Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    {
                        int insertedID = Convert.ToInt32(cmdAdd.ExecuteScalar());
                        textBoxID.Text = Convert.ToString(insertedID);
                    }
                    Connection.Close();
                }
    
            }
