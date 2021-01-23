    DataTable dt = new DataTable();
    SqlConnection oConn = new SqlConnection(); 
    SqlBulkCopy sbc = new SqlBulkCopy(oConn);
    sbc.DestinationTableName = "dbo.SomeTable";
    sbc.WriteToServer(dt);
    sbc.Close();
