        xml = new XmlDocument();
        xml.Load("D:\\connections.xml");
        string val="";
        string text = "";
        foreach (XmlNode child in xml.DocumentElement.ChildNodes)
            {
                if (child.NodeType == XmlNodeType.Element)
                {
                    //MessageBox.Show(child.Name + ": " + child.InnerText.ToString());
                    node = child.Name; //here you will get node name
                    if (node.Equals("Instruction"))
                    {
                        val = child.InnerText.ToString(); //value of the node
                        //MessageBox.Show(node + ": " + val);
                    }
                }
            }
