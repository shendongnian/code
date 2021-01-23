            foreach (XmlNode node in nodes) {
                foreach (XmlNode prop in node.ChildNodes) {
                    if (prop.NodeType != XmlNodeType.Element)
                        continue;
                    switch (prop.Name) {
                        case "View":
                            string viewType = prop.InnerText;
                            // ...
                            break;
                        case "ViewAngle":
                            string viewAngle = prop.InnerText;
                            // ...
                            break;
                        case "ViewMode":
                            string viewMode = prop.InnerText;
                            // ...
                            break;
                    }
                }
            }
