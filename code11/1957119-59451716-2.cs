    using (SqlConnection conn = new SqlConnection("connectionString")) 
                    {
                        using (SqlCommand cmd = new SqlCommand()) 
                        { 
                            cmd.Connection = conn;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = @"select EMP.ID, EMP.NAME
                from DB_TEST.DBO.EMPLOYEE as EMP 
                inner join DB_TEST.DBO.DEPARTMENT as DEPT on EMP.ID = DEPT.EMP_ID and DEPT.LANG_CH_TAG = 'english'
                where DEPT.ID = @deptId
                group by EMP.ID, EMP.NAME;";  
        
                            cmd.Parameters.AddWithValue("@deptId", deptId);  
        
                            try
                            {
                                conn.Open();
                              var reader = cmd.ExecuteReader();
                            }
                            catch(SqlException e)
                            {
                                MessgeBox.Show(e.Message.ToString(), "Error Message");
                            }
        
                        } 
                    }
