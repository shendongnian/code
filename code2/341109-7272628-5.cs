    public XDocument ParseListBoxToXml()
    {
        //build an xml document from the data in the listbox
        XDocument lstDoc = new XDocument(
            new XElement("listBox",
                new XAttribute("selectedValue", listBox.SelectedValue ?? String.Empty), new XAttribute("selectedIndex", listBox.SelectedIndex), new XAttribute("itemCount", listBox.Items.Count),
                new XElement("items",
                    from ListItem item in listBox.Items
                    select new XElement("item", new XAttribute("text", item.Text), new XAttribute("value", item.Value), new XAttribute("selected", item.Selected))
                    )
                )
            );
    
        //return the xml document
        return lstDoc;
    }
