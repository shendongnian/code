        public NewsData GetPublications()
        {
            string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
			NewsData newsData = new NewsData();
            using (var Connect = new SqlConnection(connstr))
            {
                Connect.Open();
                using (var Command = new SqlCommand("[dbo].[spNewsManagementTb_DisplayNews]", Connect))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Add("@entity_id", SqlDbType.VarChar).Value = LoggedInData.LoggedInstitutionId;
                    SqlDataReader dr = Command.ExecuteReader();
                    while (dr.Read())
                    {
                        string newsTitle = dr.GetString(0);
                        string newsMessage = dr.GetString(1);
                        string newsAuthor = dr.GetString(2);
                        DateTime newsDate = dr.GetDateTime(3);
                        string newsDateFormated = newsDate.ToString("dddd, dd MMMM yyyy");
                        
                        newsData.InfoTitle = newsTitle;
                        newsData.InfoDate = newsDateFormated;
                        newsData.InfoAuthor = newsAuthor; 
                    }
                    dr.Close();
                    Connect.Close();
                }
            }
			return newsData;
        }
