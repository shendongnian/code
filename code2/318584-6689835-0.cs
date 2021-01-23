    using System.Data;
    using System.Data.OleDb;
     
    ... 
     
    String sConnectionString = 
    "Provider=Microsoft.Jet.OLEDB.4.0;" +
    "Data Source=" + [Your Excel File Name Here] + ";" +
    "Extended Properties=Excel 8.0;";
     
    
    OleDbConnection objConn = new OleDbConnection(sConnectionString);
     
    objConn.Open();
     
    OleDbCommand objCmdSelect =new OleDbCommand("SELECT * FROM [Sheet1$]", objConn);
     
    OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
     
    objAdapter1.SelectCommand = objCmdSelect;
     
    DataSet objDataset1 = new DataSet();
     
    objAdapter1.Fill(objDataset1);
     
    objConn.Close(); 
