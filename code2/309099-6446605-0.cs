    public class ExcelHelper
        {
            public static DataTable LoadXLS(string strFile, String sheetName)
            {
                DataTable dtXLS = new DataTable(sheetName);
                try
                {
                    string strConnectionString = "";
                    if (strFile.Trim().EndsWith(".xlsx"))
                    {
                        strConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", strFile);
                    }
                    else if (strFile.Trim().EndsWith(".xls"))
                    {
                        strConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";", strFile);
                    }
                    OleDbConnection SQLConn = new OleDbConnection(strConnectionString);
                    SQLConn.Open();
                    OleDbDataAdapter SQLAdapter = new OleDbDataAdapter();
                    string sql = "SELECT * FROM [" + sheetName + "$] "; // "WHERE " + column + " = " + value;
                    OleDbCommand selectCMD = new OleDbCommand(sql, SQLConn);
                    SQLAdapter.SelectCommand = selectCMD;
    
                    SQLAdapter.Fill(dtXLS);
                    SQLConn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
    
                return dtXLS;
            }
    
            public  static DataTable QueryDataTable(DataTable dt, string column,string value)
            {
                var drs =  dt.Select(String.Format("{0} LIKE '%{1}%'", column, value));
                DataTable dt2 = dt.Clone();
                foreach (var dataRow in drs)
                {
                    dt2.ImportRow(dataRow);
                }
                return dt2;
            }
        }
