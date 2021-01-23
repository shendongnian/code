    public DataSet SortBank()
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SortBankMaster", dal.con);
                    cmd.Parameters.Add("@BankName", SqlDbType.NVarChar).Value = Bank_Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds); 
                    return ds;                 
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
      
