    using (var conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Nick\Desktop\Pricing2.xlsx;Extended Properties=""Excel 12.0 Xml;HDR=YES"";"))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT PartNumber,ShortDescription,RetailPrice,JobberPrice,BasePrice,YourDiscount,YourPrice,LongDescription FROM [Pricing$]";
        using (var adapter = new OleDbDataAdapter(cmd))
        {
            adapter.Fill(ds);
        }
    }
