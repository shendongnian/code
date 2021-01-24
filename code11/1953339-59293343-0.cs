    public static HtmlString AppendWebPString(HtmlString htmlText)
            {
    
                bool browserSupportsWebP = BrowserSupportsWebPHelper.WebPSupported();
    
                if (!browserSupportsWebP) return htmlText;
    
                var h = new HtmlDocument();
                h.LoadHtml(htmlText.ToString());
    
                const string webP = "&quality=80&format=webp";
    
                if (h.DocumentNode.SelectNodes("//img[@src]") == null) return htmlText;
    
                string modifiedHtml = htmlText.ToString();
    
                List<ReplaceImageValues> images = new List<ReplaceImageValues>();
                foreach (HtmlNode image in h.DocumentNode.SelectNodes("//img[@src]"))
                {
                    
                    var src = image.Attributes["src"].Value.Split('&');
                    string oldSrcValue = image.OuterHtml;
                    image.SetAttributeValue("src", src[0] + src[1] + string.Format(webP));
                    string newSrcValue = image.OuterHtml;
                    images.Add(new ReplaceImageValues(oldSrcValue,newSrcValue));
                }
    
    
                foreach (var newImages in images)
                {
                    modifiedHtml = modifiedHtml.Replace(newImages.OldVal, newImages.NewVal);
                }
                return new HtmlString(modifiedHtml);
            }
    
     
