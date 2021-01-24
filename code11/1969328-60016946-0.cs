    private string[] SetServiceUpdateData(XmlDocument xmlDoc)
    {
        string[] returnParms = new string[2];
    
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["Acessos"].ToString());
    
        try
        {
            using (SqlCommand cmd = new SqlCommand("dbo.sp_ServiceUpdateData", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
    
                cmd.Parameters.Add("@Id", SqlDbType.VarChar, 255).Value = ValidateParameter(xmlDoc.GetElementsByTagName("Id"));
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 255).Value = ValidateParameter(xmlDoc.GetElementsByTagName("Status"));
    
                cmd.Parameters.Add("@ERROR_CODE", SqlDbType.TinyInt, 4).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ERROR_DESCRIPTION", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
      DataSet ds = new DataSet("MyDataSet");
                conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(ds);
    
                dataReader.Close();
    
                returnParms[0] = Convert.ToString(cmd.Parameters["@Error_code"].Value);
                returnParms[1] = Convert.ToString(cmd.Parameters["@ERROR_DESCRIPTION"].Value);
            }
        }
        catch (Exception e)
        {
            returnParms[0] = returnParms[0] + e.Source;
            returnParms[1] = returnParms[1] + e.Message;
        }
        finally
        {
            if ((conn != null) && (conn.State == ConnectionState.Open))
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        return returnParms;
    }
