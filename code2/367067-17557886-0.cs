            XmlReader response = XmlReader.Create(stream);
            SyndicationFeed feeds = SyndicationFeed.Load(response);
            foreach (SyndicationItem item in feeds.Items)
            {
                if (item.ElementExtensions.Where(p => p.OuterName == "thumbnail").Count() != 0)
                {
                    string imgPath = item.ElementExtensions.Where(p => p.OuterName == "thumbnail").First().GetObject<XElement>().Attribute("url").Value;
                    MessageBox.Show(imgPath); //use it to show the img in DIV or whereever you wish.
                }
            }
