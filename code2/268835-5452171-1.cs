    DataSet ds = new DataSet();
    ds. ReadXml(@"C:\aaa.xml");
    foreach(DataTable t in ds.Tables)
    {
       string tableName = t.TableName;   // put a breakpoint here - inspect the table names
    }
