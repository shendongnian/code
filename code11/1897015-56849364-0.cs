    class Program
        {
            static void Main(string[] args)
            {
                //Declare and load your xml file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("XMLFile.xml");
    
                //Instatiate the object where you want to store the list values
                XMLData xmlData = new XMLData();
                xmlData.listKeys = new List<string>();
                xmlData.listValues = new List<string>();
    
                //Pick the settings parent node 
                XmlNode xmlSettingsNode = xmlDoc.FirstChild;
    
                //Loop through the list and add name and values to list
                foreach (XmlNode xmlNode in xmlSettingsNode.ChildNodes)
                {
                    //Ignore commented lines
                    if (xmlNode.NodeType != XmlNodeType.Comment)
                    {
                        xmlData.listKeys.Add(xmlNode.Name);
                        xmlData.listValues.Add(xmlNode.InnerText);
                    }
                }
            }
        }
    //Data model for storing list data
        public class XMLData
        {
           public List<string> listKeys { get; set; }
           public List<string> listValues { get; set; }
    
        }
