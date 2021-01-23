    List<RssFeedItem> rssItems = new List<RssFeedItem>();
                        Stream stream = e.Result;
                        XmlReader response = XmlReader.Create(stream);
                        SyndicationFeed feeds = SyndicationFeed.Load(response);
                        foreach (SyndicationItem f in feeds.Items)
                        {
                            RssFeedItem rssItem = new RssFeedItem();
    
                            rssItem.Description = f.Summary.Text;
    
     const string rx =  @"(?<=img\s+src\=[\x27\x22])(?<Url>[^\x27\x22]*)(?=[\x27\x22])"; 
                            foreach (Match m in Regex.Matches(f.Summary.Text, rx, RegexOptions.IgnoreCase | RegexOptions.Multiline))
                            {
                                string src = m.Groups[1].Value;
                                if (src.StartsWith("//")) // Google RSS has it
                                {
                                    src = src.Replace("//", "http://");
                                }
    
                                rssItem.ImageLinks.Add(src);
                            }
