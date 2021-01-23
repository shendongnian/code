           try {
               // Generate the file name to save. 
               string strUploadFileName = "C:/Documents and Settings/admin/My Documents/Visual Studio 2005/WebSites/MP/UploadFiles/" + loginuser + DateTime.Now.ToString("yyyyMMddHHmmss") + strExtension;
               // Save the Excel spreadsheet on server. 
               FileImport.SaveAs(strUploadFileName);
           // Validate the file extension. 
            if (strExtension != ".xls" && strExtension != ".xlsx" && strExtension != ".csv")
            {
                Response.Write("<script>alert('Error: Invalid Excel file');</script>");
                return;  //***UNREQUIRED FILE IS CREATED HERE***
            }
            if (strExtension == ".xls" || strExtension == ".xlsx")
            {
                    // Create Connection to Excel Workbook
                    string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strUploadFileName + ";Extended Properties=Excel 8.0;";
                    using (OleDbConnection connection =
                                 new OleDbConnection(connStr))
                    {
                        string selectStmt = string.Format("Select [Columns] FROM [Sheet1$]");
                        OleDbCommand command = new OleDbCommand(selectStmt, connection);
                        connection.Open();
                        Console.WriteLine("Connection Opened");
                        // Create DbDataReader to Data Worksheet
                        using (DbDataReader dr = command.ExecuteReader())
                        {
                            // SQL Server Connection String
                            string sqlConnectionString = "DataSource";
                            // Bulk Copy to SQL Server
                            using (SqlBulkCopy bulkCopy =
                                       new SqlBulkCopy(sqlConnectionString))
                            {
                                bulkCopy.DestinationTableName = "UserDB";
                                bulkCopy.WriteToServer(dr);
                            }
                        }
                    }
              } finally {
                  File.Delete(@strUploadFileName);
              }
