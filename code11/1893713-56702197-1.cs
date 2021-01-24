    private static String[] getDo(string DoNo)
        {           
            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["Oracle_To_Sql.Properties.Settings.Setting"].ToString()))
                {
                    String[] toReturn = new String[2];
                    string TVD_LS_NO, TVD_INV_NO;
                    string query = "select SUBSTR(TVD_DO_ITEM_NO,'1','10') from T_VEHICLE_DTL1  where TVD_LS_NO=:TVD_LS_NO";
                    OracleCommand myCommand = new OracleCommand(query, con);
                    DataTable dt = new DataTable();
                    OracleDataAdapter da = new OracleDataAdapter(myCommand);
                    da.SelectCommand = new OracleCommand(query, con);                    
                    da.Fill(dt);                    
                    foreach (DataRow row in dt.Rows)
                    {
                        TVD_LS_NO = row["TVD_LS_NO"].ToString();
                        TVD_INV_NO = row["TVD_INV_NO"].ToString();                        
                    }
                    toReturn[0] = TVD_LS_NO;
                    toReturn[1] = TVD_INV_NO;
                    return toReturn;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
