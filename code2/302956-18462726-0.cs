    public static string GetRSS()
    {
        try
        {
            XmlDocument newsUrl = new XmlDocument();
            newsUrl.Load("yoururl");
            XDocument doc = XDocument.Parse(newsUrl.InnerXml);
            var docs = doc.Root.Element("channel").ToString();
            newsUrl.LoadXml(docs);
            XmlNodeList idNodes = newsUrl.SelectNodes("channel/item");
            StringBuilder sb = new StringBuilder();
            int count = 0;
            count = idNodes.Count; 
            foreach (XmlNode node in idNodes)
            {
                sb.Append("<div><div><div><a href=" + node["nodename"].InnerText + ">" + node["nodename"].InnerText + "</a></div>");
                sb.Append("<div>" + node["nodename"].InnerText + "</div></div>");
                sb.Append("<div>" + node["nodename"].InnerText + "</div></div>");
               ........
            }
            return sb.ToString();          
        }
        catch (Exception ex)
        {
            throw ex;
        }
    
 
   
