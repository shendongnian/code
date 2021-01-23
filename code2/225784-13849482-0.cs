        private <web reference> _Service;
        private String _ListGuid, _ViewGuid;
        private Initialize()
        {
            _Service = new <web reference>.Lists();
            _Service.Credentials = System.Net.CredentialCache.DefaultCredentials;
            _Service.Url = "https://sharepointsite/_vti_bin/lists.asmx";
        }
        private String SpFieldName(String FieldName, Boolean Prefix)
        {
            return String.Format("{0}{1}", Prefix ? "ows_" : null,
                FieldName.Replace(" ", "_x0020_"));
        }
        private String GetFieldValue(XmlAttributeCollection AttributesList,
            String AttributeName)
        {
            AttributeName = SpFieldName(AttributeName, true);
            return AttributesList[AttributeName] == null ?
                null : return AttributesList[AttributeName].Value;
        }
        public void GetList()
        {
            string rowLimit = "2000"; // or whatever
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            System.Xml.XmlElement query = xmlDoc.CreateElement("Query");
            System.Xml.XmlElement viewFields = xmlDoc.CreateElement("ViewFields");
            System.Xml.XmlElement queryOptions =
                xmlDoc.CreateElement("QueryOptions");
            queryOptions.InnerXml = "";
            System.Xml.XmlNode nodes = _Service.GetListItems(_ListGuid, _ViewGuid,
                query, viewFields, rowLimit, null, null);
            foreach (System.Xml.XmlNode node in nodes)
            {
                if (node.Name.Equals("rs:data"))
                {
                    for (int i = 0; i < node.ChildNodes.Count; i++)
                    {
                        if (node.ChildNodes[i].Name.Equals("z:row"))
                        {
                            XmlAttributeCollection att =
                                node.ChildNodes[i].Attributes;
                            String title = GetFieldValue("Title");
                            String partNumber = GetFieldValue("Part Number");
                        }
                    }
                }
            }
        }
    }
