    XmlDocument doc = new XmlDocument();
    try{
    doc.Load(_indexFile);
        foreach(XmlNode node in doc.DocumentElement.ChildNodes){
            XmlAttributeCollection attrs = node.Attributes;
            foreach(XmlAttribute attr in attrs){
                Console.WriteLine(node.InnerText + ": " + attr.Name + " - " + attr.Value);
                if(attr.Name == "my-amazing-attribute")
                {
                    //Do something with attribute
                }
            }
        }
    }
    } catch (Exception ex) {
        //Do something with ex
    }
