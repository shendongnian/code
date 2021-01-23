                var retparam = new SqlParameter("@return", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.ReturnValue };
                comm.Parameters.Add(retparam);
                comm.ExecuteNonQuery();
                int ret = 0;
                if (retparam == null)
                {
                    System.Diagnostics.Debug.WriteLine("retparam was null");
                }
                else if (retparam.Value == null)
                {
                }
                else
                {
                   // use reparam.Value.ToString()
                }
