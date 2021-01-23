    internal static class XMLToListWithXPathExample
    {
        static XmlDocument xmlDocument;
        static List<BusinessObject> listBusinessObjects;
        static string sXpathStatement = "/Data/Row";
        static void LoadXMLData(string p_sXMLDocumentPath)
        {   
            xmlDocument = new XmlDocument(); // setup the XmlDocument
            xmlDocument.Load(p_sXMLDocumentPath); // load the Xml data
        }
        static void XMLDocumentToList()
        {
            listBusinessObjects = new List<BusinessObject>(); // setup the list
            foreach (XmlNode xmlNode in xmlDocument.SelectNodes(sXpathStatement)) // loop through each node
            {
                listBusinessObjects.Add( // and add it to the list
                    new BusinessObject(
                        int.Parse(xmlNode.SelectSingleNode("Id").InnerText), // select the Id node
                        xmlNode.SelectSingleNode("Name").InnerText)); // select the Name node
            }
        }
    }
    public class BusinessObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // constructor
        public BusinessObject(int p_iID, string p_sName)
        {
            Id = p_iID;
            Name = p_sName;
        }
        
    }
