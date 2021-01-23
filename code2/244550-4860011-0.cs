    using System.Data;
    using System.Data.OleDb;
    
    OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Book1.xls;Extended Properties=Excel 8.0");
    
    OleDbDataAdapter da = new OleDbDataAdapter("select * from MyObject", con);
    
    DataTable dt = new DataTable();
    da.Fill(dt);
