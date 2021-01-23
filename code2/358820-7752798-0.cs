            XmlDocument query_xml = new XmlDocument();
            query_xml.Load("Query_1.xml");
            XmlNodeList elements = query_xml.GetElementsByTagName("Attribute");
            string[] s = new string[elements.Count];
            for (int i = 0; i < elements.Count; i++)
            {
                string attrVal = elements[i].Attributes["Value1"].Value;
            Console.Writeline(attrval)
