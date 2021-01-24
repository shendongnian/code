            var sp = "dbo.sp_send_dbmail";
     using (SqlConnection con = new SqlConnection(@"Provider=SQLOLEDB.1;Data Source=ACoolServer;Initial Catalog=MSDB;User ID=MailUser;Password=Goofy;"))
                {
                    using (SqlCommand cmd = new SqlCommand(sp, con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@recipients", strLoanAssociates);
                        cmd.Parameters.Add("@subject", strSubject);
                        cmd.Parameters.Add("@body", strBody);
                        cmd.Parameters.Add("@profile_name", "EMail");
                        cmd.Parameters.Add("@body_format", "html");
                        cmd.Parameters.Add("@profile_name", strLoanAssociates);
                        cmd.Parameters.Add("@importance", "High");
                        cmd.Parameters.Add("@sensitivity", "Normal");
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
