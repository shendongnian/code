            HtmlNodeCollection TvGuideCollection = doc.DocumentNode.SelectNodes(@"//ul[@class='results']//ul//li");
            List<string> shows = new List<string>();
            foreach (HtmlNode item in TvGuideCollection)
            {
                HtmlNode title = item.SelectSingleNode(".//a");
                HtmlNode time = item.SelectSingleNode(".//span[@class='stamp']");
                if (title != null && time != null)
                {
                    string titleString = "<div class=\"show\">" + time.InnerText + " - " + title.InnerText + "</div>";
                    shows.Add(titleString);
                }
            }
