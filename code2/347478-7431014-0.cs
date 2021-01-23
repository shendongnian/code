    IEnumerable<IEnumerable<XElement>> results =
       doc.Descendants("Order")
          .Where(o => o.Attribute("OrderNumber").Value == "SO43659")
          .Select(o => o.Elements("LineItem"));
    foreach (IEnumerable<XElement> r in results)
    {
        ListBox1.Items.Add(new ListItem(r.ToString()));
    }
