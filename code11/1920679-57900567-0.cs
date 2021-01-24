    static void Main(string[] args)
        {
            List<string> result = new List<string>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("myfile.xml");
            XmlNodeList elemList = xmlDoc.GetElementsByTagName("Settings");
            foreach (XmlNode node in elemList)
            {
                if(node.Attributes["xsi:type"].Value == "FileModel")
                {
                    foreach (XmlNode item in node.ChildNodes)
                    {
                        if (item.Name == "Name")
                            result.Add(item.InnerText);
                    } 
                }
            }
        }
