            WebClient wcRSSFeeds = new WebClient();
            String rssContent;
            // Support for international chars
            Encoding encoding = wcRSSFeeds.Encoding;
            if (encoding != null)
            {
                encoding = Encoding.GetEncoding(encoding.BodyName);
            }
            else
            {
                encoding = Encoding.UTF8;  // set to standard if none given 
            }
            Stream stRSSFeeds = wcRSSFeeds.OpenRead(feedURL); // feedURL is a string eg, "http://blah.com"
            using (StreamReader srRSSFeeds = new StreamReader(stRSSFeeds, encoding, false))
            {
                rssContent = srRSSFeeds.ReadToEnd();
            }
