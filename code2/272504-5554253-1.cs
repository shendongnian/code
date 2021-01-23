    private DataSet GetStoredProcedureWithParameters(SqlConnection SQLC, 
        string StoredProcedureName, List<SqlParameter> paras)
    {
        SQLC.Open();
        SqlCommand cmdt = new SqlCommand(StoredProcedureName, WEL);
        cmdt.CommandType = CommandType.StoredProcedure;
        foreach (SqlParameter para in paras)
        {
            cmdt.Parameters.Add(para);
        }
        SqlDataAdapter dat = new SqlDataAdapter(cmdt);
        DataSet dst = new DataSet();
        dat.Fill(dst);
        SQLC.Close();
        return dst;
    }
