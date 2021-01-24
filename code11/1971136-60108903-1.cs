    private void DB_ProcStoc_Click(object sender, EventArgs e)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-JQSJAF8\SQLEXPRESS;Initial Catalog=TRTF_TagLogging;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("PS_TagLogging", connection))
                    {
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;                  
                        cmd.Parameters.Add("@DataStart", SqlDbType.DateTime).Value = new DateTime(2020, 02, 05, 13, 06, 30, 697);
                        cmd.Parameters.Add("@DataStop", SqlDbType.DateTime).Value = new DateTime(2020, 02, 05, 13, 12, 25, 703);//2020, 02, 05, 13, 12, 25, 703   //2020, 02, 05, 13, 06, 50, 700
                       
                        var values = new List<int>();
                        var valData = new List<DateTime>();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            values.Add(reader.GetInt64(0));//reads the value of my first column (ID) from DB
                            values.Add(reader.GetInt32(1));//reads the value of my second column (Tag1) from DB
                            valData.Add(reader.GetDateTime(2));//reads the date from my third column of DB
                        }
    
                        strCol = String.Join(" ", values);
                        strDate = String.Join(" ", valData);
                        
    
                        connection.Close();
                    }
                }
                //MessageBox.Show("Proc: " + strCol + " values");
                MessageBox.Show("Date: "+ strDate);            
            }
