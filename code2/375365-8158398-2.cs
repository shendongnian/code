    // create XML element representing one "Item", containing a "Name" and an "Amount" 
    // and add it to the given parent element
    private void AddItem(XElement parent, string itemName, int amount)
    {
        // create new XML element for item
        XElement newItem = new XElement("Item");
        // add the name
        newItem.Add(XElement.Parse("<Name>" + itemName + "</Name>"));
        // add the amount
        newItem.Add(XElement.Parse("<Amount>" + amount + "</Amount>"));
        // add to parent XML element given by caller
        parent.Add(newItem);
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        // create new document (in your case you would do this only once, 
        // not on every button click)
        XDocument doc = XDocument.Parse("<Items />");
        // doc.Root is <Items /> - lets add some items
        AddItem(doc.Root, "My item", 42);
        AddItem(doc.Root, "Another item", 84);
            
        // check if we succeeded (of course we did!)
        Debug.WriteLine(doc.ToString());
    }
