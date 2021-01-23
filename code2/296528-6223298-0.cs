    DataTable dt = new DataTable();
    try
    {
       OleDbConnection con = new OleDbConnection(string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=yes;IMEX=1""", excelPath));
       OleDbDataAdapter da = new OleDbDataAdapter("select * from [sheetname$]", con);
    
       da.Fill(dt);
    }
    catch (Exception ex)
    {
       MessageBox.Show(ex.Message);
       return;
    }
    //now you can use dt DataTable
    foreach (DataRow dr in dt.Rows)
    {
      //....
    }
