    public class DocumentLoader
        {
            private readonly string content;
            public  DocumentLoader(Stream stream):this(new StreamReader(stream).ReadToEnd())
            {
                
            }
            public DocumentLoader(string content)
            {
                this.content = content;
    
            }
            public KeyValuePair<string,string>[] GetNames()
        {
            List<KeyValuePair<string,string>> names=new List<KeyValuePair<string,string>>();
            XmlDocument document=new XmlDocument();
            document.LoadXml(this.content);
            XmlNodeList xmlNodeList = document.SelectNodes("//publication");
            if(xmlNodeList!=null)
            {
                foreach (XmlNode node in xmlNodeList)
                {
                    var key = node.InnerText;
                   string value = "";
                    if (node.Attributes != null)
                    {
                        value = node.Attributes["tcmid"].Value;
                    }
                    names.Add(new KeyValuePair<string, string>(key,value));
                }
            }
            return names.ToArray();
        }
        }
