    private static XElement Sort(XElement element)
    {
        var xe = new XElement(element.Name, element.Elements().OrderBy(x => x.Name.ToString(), new SplitComparer()).Select(x => Sort(x)));
    
        if (!xe.HasElements)
        {
            xe.Value = element.Value;
        }
    
        return xe;
    }
    
    private static XDocument Sort(XDocument file)
    {
        return new XDocument(Sort(file.Root));
    }
