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
            public string[] GetNames()
            {
                List<String> names=new List<string>();
                XmlDocument document=new XmlDocument();
                document.LoadXml(this.content);
                XmlNodeList xmlNodeList = document.SelectNodes("//name");
                if(xmlNodeList!=null)
                {
                    foreach (XmlNode node in xmlNodeList)
                    {
                        names.Add(node.InnerText);
                    }
                }
                return names.ToArray();
            }
        }
