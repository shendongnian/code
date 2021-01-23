    using Oracle.DataAccess;
    using Oracle.DataAccess.Client;
    
    public DataTable GetHeader_BySproc(string unit, string office, string receiptno)
                {
                    using (OracleConnection cn = new OracleConnection(DatabaseHelper.GetConnectionString()))
                    {
                        OracleDataAdapter da = new OracleDataAdapter();
                        OracleCommand cmd = new OracleCommand();
                        cmd.Connection = cn;
                        cmd.InitialLONGFetchSize = 1000;
                        cmd.CommandText = DatabaseHelper.GetDBOwner() + "PKG_COLLECTION.CSP_COLLECTION_HDR_SELECT";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("PUNIT", OracleDbType.Char).Value = unit;
                        cmd.Parameters.Add("POFFICE", OracleDbType.Char).Value = office;
                        cmd.Parameters.Add("PRECEIPT_NBR", OracleDbType.Int32).Value = receiptno;
                        cmd.Parameters.Add("T_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            
                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            
               
