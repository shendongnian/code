    List<Details> detailsList = new List<Details>();
    XmlDocument doc = new XmlDocument();
    doc.Load(path);
    XmlNodeList nodeList = doc.SelectNodes("/Invoice/InvoiceHeader");
    foreach (XmlNode node in nodeList)
    {
        // create details class for each InvoiceHeader
        Details detail = new Details();
        detail.Number = new List<string>();
  
        // loop over child nodes to get Name and all Number elements
        foreach (XmlNode child in node.ChildNodes)
        {  
            // check node name to decide how to handle the values               
            if (child.Name == "Name")
            {
                detail.Name = child.InnerText;
            }
            else if (child.Name == "Number")
            {
                detail.Number.Add(child.InnerText);
            }                    
        }
        detailsList.Add(detail);
    } 
