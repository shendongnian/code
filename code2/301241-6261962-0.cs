    IEnumerable<XElement> query = root.Elements("OrderNum").Elements("ServiceJob");
    for(int i = 0; i < combArray.GetLength(0); i++)
    {
        if(combArray[i].Text != "All")
            query = query.Where(arg => arg.Element(combArray[i].AccessibleName) == combArray[i].Text)
    }
    var result = query.ToList();
