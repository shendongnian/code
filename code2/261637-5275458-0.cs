    DataTable table = CreatePermissionTable(); // uses the c# code listed in question
    DataSet ds = new DataSet();
    ds.Tables.Add(table);
    try
    {
        using(Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
        {
            ds.ReadXml(stream);
            table = ds.Tables["Permission"];
            return table;
        }
    }
