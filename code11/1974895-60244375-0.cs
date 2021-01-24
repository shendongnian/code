    public static List<string> fillInstCategory()
    {
        string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        SqlConnection Connect = null;
        SqlCommand Command;
        List<string> categories = new List<string>();
        using (Connect = new SqlConnection(connstr))
        {
            Connect.Open();
            using (Command = new SqlCommand("[dbo].[spMetadataTb_GetCategory]", Connect))
            {
                Command.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = Command.ExecuteReader();
                while (dr.Read())
                {
                    string categoryInst = dr.GetString(0);
                    categories.Add(categoryInst);
                }
            }
    
            Command.Dispose();
            Connect.Close();
            return categories;
        }
    }
