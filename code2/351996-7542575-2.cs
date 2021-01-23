       using (SqlConnection con = new SqlConnection(dc.Con))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ADD", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", txtfirstname);
                        cmd.Parameters.AddWithValue("@LastName", txtlastname);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    
                }
