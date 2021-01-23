    public bool ConnectToDB()
    {
        SqlConnection sqlConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString());
        try
        {
            sqlConnect.Open();
            if (sqlConnect.State == ConnectionState.Open)
            {
                return true;
            }else 
    return false;
        }
        catch (SqlException ex)
        {
            return false;
        }
        finally
        {
            sqlConnect.Close();
        }
    }
