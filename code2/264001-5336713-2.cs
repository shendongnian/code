    public static string TryGetElementValue(this XElement parentEl, string elementName, string defaultValue = null) 
    {
        var foundEl = parentEl.Element(elementName);
        if (foundEl != null)
        {
            return foundEl.Value;
        }
        return defaultValue;
    }
