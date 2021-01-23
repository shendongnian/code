    using System.Configuration;
    using System.Data;
    using Oracle.DataAccess.Client;
    
    
        namespace Testing
        {
            public class OracleCommandTest
            {
        
                string m_strConnectionsString = string.Empty;
        
                //Constructor
                public OracleCommandTest()
                {
                    //Get the connection string from the app.config            
                    m_strConnectionsString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
        
                    //if it is a web app, then use this call instead
                    //m_strConnectionsString = WebConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
        
                }
        
        
        
                public void getData(string sNom, out string sValeur, out string sCommentaire, out string sRetour, out string sMsgRetour)
                {
                    OracleConnection ora_conn = new OracleConnection(m_strConnectionsString);
        
                    try
                    {
                        ora_conn.Open();
        
                        /*********************Oracle Command**********************************************************************/
                        OracleCommand ora_cmd = new OracleCommand("MYPKG.MYPROCEDURE", ora_conn);
                        ora_cmd.BindByName = true;
                        ora_cmd.CommandType = CommandType.StoredProcedure;
        
        
                        ora_cmd.Parameters.Add("sNom", OracleDbType.Varchar2, sNom, ParameterDirection.Input);
                        ora_cmd.Parameters.Add("sValeur", OracleDbType.Varchar2, ParameterDirection.Output);
                        ora_cmd.Parameters.Add("sCommentaire", OracleDbType.Varchar2, ParameterDirection.Output);
                        ora_cmd.Parameters.Add("sRetour", OracleDbType.Varchar2, ParameterDirection.Output);
                        ora_cmd.Parameters.Add("sMsgRetour", OracleDbType.Varchar2, ParameterDirection.Output);
                        /*********************Oracle Command**********************************************************************/
        
                        ora_cmd.ExecuteNonQuery();
        
                        //Now get the values output by the stored procedure    
                        sValeur = ora_cmd.Parameters["sValeur"].Value.ToString();
                        sCommentaire = ora_cmd.Parameters["sCommentaire"].Value.ToString();
                        sRetour = ora_cmd.Parameters["sRetour"].Value.ToString();
                        sMsgRetour = ora_cmd.Parameters["sMsgRetour"].Value.ToString();
        
        
        
        
                    }
        
                    //catch (Exception ex)
                    //{
                    //    WebErrorHandling.WriteToEventLog("PRVEquipment_DAL.getPRVEquipment", ex);
        
                    //}
                    finally
                    {
                        if (ora_conn.State == ConnectionState.Open)
                        {
                            ora_conn.Close();
                        }
                    }
        
                }
        
        
            }
        
        
        }
