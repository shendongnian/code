    public static List<RssFeedItem> ReadFeed(string url)
        {
            List<RssFeedItem> rssItems = new List<RssFeedItem>();
            HttpWebRequest rssFeed = (HttpWebRequest)WebRequest.Create(url);
            rssFeed.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E)";
            using (DataSet rssData = new DataSet())
            {
                var response = rssFeed.GetResponse();
                var data = response.GetResponseStream();
                rssData.ReadXml(data);
                foreach (DataRow datarow in rssData.Tables["item"].Rows)
                {
                    rssItems.Add(new RssFeedItem
                    {
                        description = Convert.ToString(datarow["description"]),
                        /********
                        language = Convert.ToString(datarow["language"]),
                        *********/
                        link = Convert.ToString(datarow["link"]),
                        pubdate = Convert.ToString(datarow["pubdate"]),
                        title = Convert.ToString(datarow["title"])
                    });
                }
            }
            return rssItems;
        }
