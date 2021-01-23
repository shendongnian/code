    String getURL(){
    return @"some site address";
    }
    List<string> Internalscripts()
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlWeb().Load((@"" + getURL()));
            //Getting All the JavaScript in List
            HtmlNodeCollection javascripts = doc.DocumentNode.SelectNodes("//script");
            List<string> scriptTags = new List<string>();
            foreach (HtmlNode script in javascripts)
            {
                if(!script.Attributes.Contains(@"src"))
                {
                    scriptTags.Add(script.InnerHtml);
                }
            }
            return scriptTags;
        }
