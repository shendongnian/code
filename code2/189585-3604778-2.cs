    public static class NewClass
    {
        public static string[] GetCompletionList(string prefixText, int count, string contextKey)
        {
            SqlConnection con;
            SqlCommand cmd;
            string cmdString = "SELECT TOP(15) Title FROM posts WHERE (Title LIKE '%" + prefixText + "%') OR (Content LIKE '%" + prefixText + "%')";
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbMyCMSConnectionString"].ConnectionString);
        
            cmd = new SqlCommand(cmdString, con);
            con.Open();
        
            SqlDataReader myReader;
            List<string> returnData = new List<string>();
        
            myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        
            while (myReader.Read())
            {
                returnData.Add(myReader["Title"].ToString());
            }
        
            myReader.Close();
            con.Close();
        
            return returnData.ToArray();
        }
    }
