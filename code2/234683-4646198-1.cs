    public int InsertCompanyDetailsInformation(int companyId, int bankId, int accountNo, string accountType)
    {
        int rowsAffected = -1;
        int returnValue;
        try
        {
            SqlConnection con = DBProvider.GetDbConnection();
            using (con)
            {
                con.Open();
                SqlCommand objCmd = new SqlCommand("dbo.sp_InsertCompanyDetailsInformation", con);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@companyId", companyId);
                objCmd.Parameters.AddWithValue("@bankId", bankId);
                objCmd.Parameters.AddWithValue("@accountNo", accountNo);
                objCmd.Parameters.AddWithValue("@accountType", accountType);
                rowsAffected = objCmd.ExecuteNonQuery();
                SqlParameter sqlParam = objCmd.Parameters.Add("@insert_flag", SqlDbType.Int);
                sqlParam.Direction = ParameterDirection.ReturnValue;
                // now execute the command 
                objCmd.Parameters.Add(sqlParam);
                con.Open();
                rowsAffected = objCmd.ExecuteNonQuery();
                con.Close();
                returnvalue = (int)objCmd.Parameters["insert_flag"].Value;
                
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rowsAffected;
    } 
}
