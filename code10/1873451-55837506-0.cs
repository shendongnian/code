    public static DataSet ToDataSet(IDataReader reader)
    {
        DataSet ds = new DataSet();
        while (!reader.IsClosed)
        {
            DataTable dt = new DataTable();
            dt.Load(reader);
            ds.Tables.Add(dt);
        }
        return ds;
    }
