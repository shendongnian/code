    using (var conn = new SqlConnection(@"<your conn str>"))
    {
        var ds = new DataSet();
        using (var invoiceCmd = conn.CreateCommand())
    
        //One of these per table to export
        using(var invoiceAdapter = new SqlDataAdapter(invoiceCmd))
        {
            invoiceCmd.CommandText = "SELECT * FROM Attendance";
            invoiceAdapter.Fill(ds, "Attendance");
        }
    
        ds.WriteXml(@"C:\temp\foo.xml");
    }
       
