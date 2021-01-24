            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Source\Testing\XML\doc.xml");
            // This line will select "the first node" in the XML Document with attribute Name="C"
            XmlNode nodeControlItem = doc.SelectSingleNode("//*[@Name='C']");
            // Alternatively, you can accomplish the same thing by iterating through all of the ControlItem nodes to find the one you want:
            foreach (XmlNode node in doc.SelectNodes("/GradeLimits/ControlItems/ControlItem"))
            {
                if (node.Attributes.GetNamedItem("Name").Value == "C")
                {
                    nodeControlItem = node;
                    break;
                }
            }
            //Now that you have your "C" ControlItem, you can find a child node with Type="UpperWarningLimit"
            XmlNode nodeLimitValue = nodeControlItem.SelectSingleNode("//*[@Type='UpperWarningLimit']");
            //Alternatively, you can accomplish the same thing by iterating through all of the ChildNodes of the ControlItem to find the one you want:
            foreach (XmlNode childNode in nodeControlItem.ChildNodes)
            {
                if (childNode.Attributes.GetNamedItem("Type").Value == "UpperWarningLimit")
                {
                    nodeLimitValue = childNode;
                    break;
                }
            }
            //Or, another is to iterating through all of the LimitValue child nodes of the ControlItem to find the one you want:
            foreach (XmlNode childNode in nodeControlItem.SelectNodes("./LimitValue"))
            {
                if (childNode.Attributes.GetNamedItem("Type").Value == "UpperWarningLimit")
                {
                    nodeLimitValue = childNode;
                    break;
                }
            }
            Console.Write(nodeLimitValue.Value);
            // Modify the value of the node
            nodeLimitValue.Value = "0.00000";
            Console.Write(nodeLimitValue.Value);
            // Save the XML document back to disk
            doc.Save(@"C:\Source\Testing\XML\doc.xml");
