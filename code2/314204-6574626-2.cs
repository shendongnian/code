        public JsonpResult About(string HomePageUrl)
        {
            Models.Pocos.About about = null;
            // ************* CHANGE HERE - added "timeout in milliseconds" to RemoteFileExists extension method.
            if (HomePageUrl.RemoteFileExists(1000))
            {
                // Using the Html Agility Pack, we want to extract only the
				// appropriate data from the remote page.
                HtmlWeb hw = new HtmlWeb();
                HtmlDocument doc = hw.Load(HomePageUrl);
                HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[@class='wrapper1-border']");
                if (node != null)
                { 
                    about = new Models.Pocos.About { html = node.InnerHtml };
                }
                    //todo: look into whether this else statement is necessary
                else 
                {
                    about = null;
                }
            }
            return this.Jsonp(about);
        }
