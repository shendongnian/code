    public static DataTable resort(DataTable dt, string colName, string direction)
    {
        dt.DefaultView.Sort = colName + " " + direction;
        dt = dt.DefaultView.ToTable();
        return dt;
    }
