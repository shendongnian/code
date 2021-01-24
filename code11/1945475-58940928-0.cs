            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml("<a class=\"tag tag - red - dark\" title=\"a > b\" href=\" / keywords ? q = PARTOFATTRIBUTE\"> < Found TEXTCONTENT </a>");
            if (htmlDoc.DocumentNode.ChildNodes[0].InnerHtml.Contains("TEXTCONTENT"))
            {
                // do something with text content
            }
            if (htmlDoc.DocumentNode.ChildNodes[0].Attributes["href"].Value.Contains("PARTOFATTRIBUTE"))
            {
                // do something with attribute
            }
