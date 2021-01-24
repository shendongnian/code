private static void DeleteXmlNode(string path, string tagname, string searchVal)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList nodes = doc.GetElementsByTagName(tagname);
            XmlNode root = doc.DocumentElement;
            foreach (XmlNode n in root)
            {
                if (n.Attributes["Id"].Value == searchVal)
                {
                    root.RemoveChild(n);
                }
            }
            using (var tw = new StreamWriter(@"~../../../../Log/Log.txt".Trim(), true))
            {
                tw.WriteLine(DateTime.Now + "\t" + WinId + "\t DELETED Job ::: " + searchVal);
            }
            doc.Save(path);
        }
