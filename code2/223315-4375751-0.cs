    public string RunAnalysis(string localServer, string userName, string password, string selectedDatabase)
    {
        DataTable dt = GetAllPrimaryKeyTables(localServer, userName, password, selectedDatabase);
        StringBuilder sb = new StringBuilder();
        foreach (DataRow dr in dt.Rows)
        {
            sb.AppendLine(dr.IsNull(0) ? "" : dr[0].ToString());
        }
        return sb.ToString();
    }
