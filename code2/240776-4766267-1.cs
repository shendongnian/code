    ApplicationClass myExcel;
    try
    {
    myExcel = GetObject(,"Excel.Application")
    }
    Catch (Exception ex)
    {
    myExcel = New ApplicationClass()
    }
    myExcel.Visible = true;
    Workbook wb1 = myExcel.Workbooks.Add("");
    Worksheet ws1 = (Worksheet)wb1.Worksheets[1];
    //Read the connection string from App.Config
    string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["NewConnString"].ConnectionString;
    //Open a connection to the database
    SqlConnection myConn = new SqlConnection();
    myConn.ConnectionString = strConn;
    myConn.Open();
    //Establish the query
    SqlCommand myCmd = new SqlCommand("select * from employees", myConn);
    SqlDataReader myRdr = myCmd.ExecuteReader();
    //Read the data and put into the spreadsheet.
    int j = 3;
    while (myRdr.Read())
    {
    for (int i=0 ; i < myRdr.FieldCount; i++)
    {
    ws1.Cells[j, i+1] = myRdr[i].ToString();
    }
    j++;
    }
    //Populate the column names
    for (int i = 0; i < myRdr.FieldCount ; i++)
    {
    ws1.Cells[2, i+1] = myRdr.GetName(i);
    }
    myRdr.Close();
    myConn.Close();
    //Add some formatting
    Range rng1 = ws1.get_Range("A1", "H1");
    rng1.Font.Bold = true;
    rng1.Font.ColorIndex = 3;
    rng1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
    
    Range rng2 = ws1.get_Range("A2", "H50");
    rng2.WrapText = false;
    rng2.EntireColumn.AutoFit();
    //Add a header row
    ws1.get_Range("A1", "H1").EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, Missing.Value);
    ws1.Cells[1, 1] = "Employee Contact List";
    Range rng3 = ws1.get_Range("A1", "H1");
    rng3.Merge(Missing.Value);
    rng3.Font.Size = 16;
    rng3.Font.ColorIndex = 3;
    rng3.Font.Underline = true;
    rng3.Font.Bold = true;
    rng3.VerticalAlignment = XlVAlign.xlVAlignCenter;
    //Save and close
    string strFileName = String.Format("Employees{0}.xlsx", DateTime.Now.ToString("HHmmss"));
    System.IO.File.Delete(strFileName);
    wb1.SaveAs(strFileName, XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlExclusive, Missing.Value, false, Missing.Value, Missing.Value, Missing.Value);
    myExcel.Quit();
}
