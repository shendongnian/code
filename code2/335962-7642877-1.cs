            XmlTextReader reader = new XmlTextReader("data.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            string path4 = treeView1.SelectedNode.FullPath.ToString();       
     
            // now replace '\' by '/'
            path4 = path4.Replace('\\', '/');
            // appending '/' at beginning
            path4 = "/" + path4;           
            
            XmlNode nodeToRemove = doc.SelectSingleNode(path4);
            XmlNode parentNode = nodeToRemove.ParentNode;
            parentNode.RemoveChild(nodeToRemove);
