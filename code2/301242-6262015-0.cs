    XElement root = XElement.Load(fileName);
    IEnumerable<XElement> selectedElements = root.Elements("OrderNum").Elements("ServiceJob");
    
    for(int i = 0; i < combArray.GetLength(0); i++)
    {
        if(combArray[i].Text != "All")
        {
            selectedElements = selectedElements.Where(el => el.Element(combArray[i].AccessibleName) == combArray[i].Text);
        }
    }
    
    var result = selectedElements.ToList();
