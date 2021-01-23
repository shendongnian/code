    private DataTable GetDataTableFromInHouseAdapter()
    {
        using (InHouseDataAdapter inHouseDataAdapter = new InHouseDataAdapter())
        using (SqlCommand cmd = new SqlCommand())
        {
            return inHouseDataAdapter.GetDataTable(cmd);
        }
    }
    ...
    List<MyObject> listToReturn = new List<MyObject>();
    using (DataTable dt = GetDataTableFromInHouseAdapter())
    {
        foreach (DataRow dr in dt.Rows)
        {
            listToReturn.Add(new MyObject(dr));
        }
    }
