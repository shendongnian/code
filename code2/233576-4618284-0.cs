    public class Data
    {
        string tagName;
        string value;
        public Data(string tagName, string value)
        {
            this.tagName = tagName;
            this.value = value;
        }
        public static List<Data> Parse(XmlNodeList nodes)
        {
            List<Data> listData = new List<Data>();
            foreach (XmlNode node in nodes)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    Data data = new Data(childNode.Name, childNode.InnerText);
                    listData.Add(data);
                }
            }
            return listData;
        }
    }
