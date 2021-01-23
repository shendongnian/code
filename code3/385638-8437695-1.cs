     private bool DownloadExcelData(string fileName, ref DataTable informationDT)
                {
                    // bool success
                    bool success = true;
        
                    // open the file via odbc
                    string connection = ConfigurationManager.ConnectionStrings["xls"].ConnectionString;
                    connection = String.Format(connection, FilePath + fileName);
                    OleDbConnection conn = new OleDbConnection(connection);
                    conn.Open();
        
                    try
                    {
                        // retrieve the records from the first page
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Information$]", conn);
                        OleDbDataAdapter adpt = new OleDbDataAdapter(cmd);
                        adpt.Fill(informationDT);
                    }
                    catch { success = false; }
        
                    // close the connection
                    conn.Close();
                    return success;
                }
