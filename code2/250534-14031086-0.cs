    public static DataTable resort(DataTable dt, string colName, string direction)
    {
        DataTable dtOut = null;
        dt.DefaultView.Sort = colName + " " + direction;
        dtOut = dt.DefaultView.ToTable();
        return dtOut;
    }
