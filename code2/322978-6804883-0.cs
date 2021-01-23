        public static IList<Post> FindPostsByWebSiteList(string[] urls)
        {
            var pl = new List<Post>();
            var urlArray = urls.Select((x,y) => "@url" + y.ToString()).ToArray();
            var urlsJoined = string.Join(",", urlArray);
            string q = string.Format("select Id, Url, Title, Date, ImageUrl from post where WebSiteUrl IN ({0})", urlsJoined);
            using (MySqlConnection con = new MySqlConnection(WebConfigurationManager.ConnectionStrings["MySqlConnectionString"].ToString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    for (int x = 0; x < urlArray.Length; x++)
                    {
                        cmd.Parameters.Add(urlArray[x], MySqlDbType.Text).Value = urls[x];
                    }
                    
                    con.Open();
                    var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        var p = new Post();
                        p.Id = reader.GetInt32("Id");
                        p.Url = reader.GetString("Url");
                        p.Title = reader.GetString("Title");
                        p.Date = reader.GetDateTime("Date");
                        p.ImageUrl = reader.GetString("ImageUrl");
                        pl.Add(p);
                    }
                    return pl;
                }
            }
        }
