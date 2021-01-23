     private void button1_Click(object sender, EventArgs e)
            {
                
                string StartDate = Start_Date.Value.Date.ToString("MM/dd/yyyy").Replace("-", "/");
                string EndDate = End_Date.Value.Date.ToString("MM/dd/yyyy").Replace("-", "/");
    
                string LogFolder = @"C:\Log\";
                try
                {
                    string StoredProcedureName = comboBox1.Text;
              
                    SqlConnection SQLConnection = new SqlConnection();
                    SQLConnection.ConnectionString = ConnectionString;   
    
                    //Load Data into DataTable from by executing Stored Procedure
                    string queryString =
                      "EXEC  " + StoredProcedureName + " @Ifromdate ='" + StartDate + "',@Itodate ='" + EndDate+"'";
    
    
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, SQLConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DataTable DtValue = new DataTable();
                    DtValue = (ds.Tables[0]);
    
    
                }
    
                catch (Exception exception)
                {
                    // Create Log File for Errors
                    using (StreamWriter sw = File.CreateText(LogFolder
                        + "\\" + "ErrorLog_" + datetime + ".log"))
                    {
                        sw.WriteLine(exception.ToString());
                    }
                }
    
            }
    
    ///JUST add ClosedXMl.dll
            public void DataTableToExcel(DataTable dt)
            {
                string FileName = "Records";
                string SheetName = "Records";
                string folderPath = "C:\\New\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, SheetName);
                    wb.SaveAs(folderPath + "\\" + FileName + ".xlsx");
                }
            }
