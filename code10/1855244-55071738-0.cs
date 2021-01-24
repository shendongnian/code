            foreach (XmlNode node in xdoc.SelectNodes("/eventlist/event[@type='AUDIOPLAYER']"))
            {
                XmlNodeList srcNodes = node.SelectNodes("/eventlist/event[@type='AUDIOPLAYER']");
                foreach (XmlNode srcNode in srcNodes)
                {
                    XmlNode newElem = xdoc.CreateElement("event");
                    XmlAttribute newAttr = xdoc.CreateAttribute("type");
                    newAttr.Value = "VIZ";
                    newElem.Attributes.Append(newAttr);
                    srcNode.ParentNode.InsertAfter(newElem, srcNode);
                }
            }
The problem is you were selecting single node from matching expression, and you need to select all the nodes that match that and insert the new node after each of them.
Hope this helps!
