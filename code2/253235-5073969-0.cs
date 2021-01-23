    using System.Data.OleDb;
    using System.Data;
    
    
    public DataTable GetDataTableFromExcel(string FilePath, string strTableName)
            {
                string XLSConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                //string XLSConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1'";
                OleDbConnection XLSCon = new OleDbConnection(XLSConnectionString);
                OleDbDataAdapter XLSDataAdp = new OleDbDataAdapter();
                XLSDataAdp.SelectCommand = new OleDbCommand();
                XLSDataAdp.SelectCommand.Connection = XLSCon;
                try
                {
                    DataTable dtXLSData = new DataTable();
                    XLSCon.Open();
                    XLSDataAdp.SelectCommand.CommandText = "SELECT * FROM [" + strTableName + "$]";
                    XLSDataAdp.Fill(dtXLSData);
    
                    return dtXLSData;
    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    XLSCon.Close();
                }
            }
