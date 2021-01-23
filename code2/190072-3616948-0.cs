        public void updateXmlFile(string strFileName)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(strFileName);
                string newValue = GetUniqueKey();
                XmlNodeList list = doc.SelectNodes("//@*"); // Forgot the slashes here...
                IEnumerable<XmlNode> filteredList = list.Cast<XmlNode>().
                    Where(item => item.Name.ToLower().Contains("name")); // Name property instead of Value
                foreach (XmlNode n in filteredList)
                {
                    n.Value = newValue; // Setting the value.
                    Console.WriteLine("FILTERED NODES ARE : {0}", n.Value);
                }
                doc.Save(strFileName);
            }
            catch (XmlException xex) { Console.WriteLine(xex); }
        }
