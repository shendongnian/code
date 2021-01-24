    XmlNode Node = XMLDocument.SelectSingleNode("Data");
                MyItem item = new MyItem();
                string name = item.name;
                string age = item.Age;
                GetString(Node, "Name", ref name);
                GetString(Node, "Age", ref age);
