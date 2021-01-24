                xmlCordinates cordinates = new xmlCordinates();
                cordinates.fileName = node["Name"].InnerText;
                cordinates.X = Convert.ToDouble(**node.ChildNodes[2]["x"].InnerText**);
                cordinates.Y = Convert.ToDouble(**node.ChildNodes[2]["y"].InnerText**);
                ListCordintes.Add(cordinates);
