    public static class XElementExtensions
    {
        public static XElement GetElement(this XElement element, XName elementName)
        {
            if (element != null)
            {
                XElement child = element.Element(elementName);
                if (child != null)
                {
                    return child;
                }
            }
            return null;
        }
        public static String GetElementValue(this XElement element, XName elementName)
        {
            if (element != null)
            {
                XElement child = element.Element(elementName);
                if (child != null)
                {
                    return child.Value;
                }
            }
            return null;
        }
    }
