    var results = doc.Descendants("Order")
                     .Where(o => o.Attribute("OrderNumber").Value == "SO43659")
                     .FirstOrDefault();
    
    foreach (var r in results.Elements("LineItem"))
    {
        ListBox1.Items.Add(new ListItem(r.ToString()));
    }
