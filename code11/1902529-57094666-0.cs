    public static class Data
    {
    
    public DataTable Get(string cmdText)
    {
    DataTable dt = new DataTable("Test");
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LIVE"].ConnectionString))
    {
    da.SelectCommand = con.CreateCommand();
    da.SelectCommand.CommandType = CommandType.Text;
    da.SelectCommand.CommandText = cmdText;
    da.SelectCommand.Connection = con;
    try
    {
    con.Open();
    da.Fill(dt);
    con.Close();
    }
    catch (Exception ec)
    {
    
    }
    finally
    {
    
    con.Close();
    }
    
    }
    return dt;
    }
    
    }
