        var nodes = htmlDoc.DocumentNode.SelectNodes("//li[@class='itemRow productItemWrapper']");
                foreach(HtmlNode node in nodes)
                {
                    var nodeDoc = new HtmlDocument();
                    nodeDoc.LoadHtml(node.InnerHtml);
    
    string name = nodeDoc.DocumentNode.SelectSingleNode("//span[@class='productDetailTitle']").InnerText;
                }
