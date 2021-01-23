            List<string> images = new List<string>();
            WebClient client = new WebClient();
            string site = "http://www.mysite.com";
            var htmlText = client.DownloadString(site);
            var htmlDoc = new HtmlDocument()
                        {
                            OptionFixNestedTags = true,
                            OptionAutoCloseOnEnd = true
                        };
            htmlDoc.LoadHtml(htmlText);
            foreach (HtmlNode img in htmlDoc.DocumentNode.SelectNodes("//img"))
            {
                HtmlAttribute att = img.Attributes["src"];
                images.Add(att.Value);
            }
