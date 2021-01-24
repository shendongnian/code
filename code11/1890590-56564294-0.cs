    private T GetData<T>(string query, string tblName) 
        where T : DataSet, new()
    {
        string conString = .... ;     
        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;             
                // Use T here instead of TypedDataSet
                using (T tds = new T())
                {
                    sda.Fill(tds , tblName);
                    return tds;
                }
            }
        }    
    }
