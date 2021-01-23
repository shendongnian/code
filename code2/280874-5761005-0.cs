                using (XmlReader reader = XmlReader.Create(path))
                {
                    SyndicationFeed feed = SyndicationFeed.Load(reader);
                    if ((feed != null) && (feed.LastUpdateTime > feedLastUpdated))
                    {
                        // Launch Process                            
                    }
                }
