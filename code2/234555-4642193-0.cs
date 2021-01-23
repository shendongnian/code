     using (XmlReader reader = XmlReader.Create(Settings.Default.ExchangeRateFeed))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                if (feed != null)
                {
                    foreach (var item in feed.Items)
                    {
                        // Code to obtain required properties
                    }
                }
            }
