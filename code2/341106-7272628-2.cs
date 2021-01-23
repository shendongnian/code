    public XDocument ParseListBoxToXml()
    {    
        //build an xml document from the items in the listbox
        XDocument lstXml = new XDocument(
            new XElement("items",
                from ListItem item in listBox.Items
                select new XElement("item",
                    new XAttribute("Text", item.Text), new XAttribute("Value", item.Value), new XAttribute("Selected", item.Selected)
                    )
                )
            );
    
        //return the listbox xml
        return lstXml;
    }
