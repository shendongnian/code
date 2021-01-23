        CrystalReport1 myReport;    
 
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\4.accdb";  
        string selectSQL = "Select ProductID,ProductName,ProductSpec From Products";  
 
        OleDbConnection connection = new OleDbConnection(connectionString);  
        OleDbDataAdapter da = new OleDbDataAdapter(selectSQL, connection);  
 
        DataSet ds = new DataSet();  
        da.Fill(ds, "Test");  
 
        myReport = new CrystalReport1();  
        myReport.SetDataSource(ds);  
        myReportViewer1.ReportSource = myReport;  
 
        ds.Dispose();  
        connection.Close();     
