    ManagementObject first = null;
    foreach (var element in searcher.Get())
    {
        if (Satisfy(element))
        {
            first = element;
            break;
        }
        else
        {
            element.Dispose();    
        }
    }
    
    if (first == null)
    {
        throw new InvalidOperationException("No match");
    }
