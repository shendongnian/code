    public void ClearOrderToggle(string RepRef)
    {
        MySQLConnection.Open();
        SqlCommand cmdt = new SqlCommand("MyStoredProcedureName", 
            MySQLConnection);
        cmdt.CommandType = CommandType.StoredProcedure;
        SqlParameter para = cmdt.Parameters.Add("@ParameterName", 
            System.Data.SqlDbType.VarChar);
        para.Value = ParameterValue;
        para.Direction = ParameterDirection.Input;
        cmdt.ExecuteNonQuery();
        MySQLConnection.Close();
    }
