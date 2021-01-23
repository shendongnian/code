    public static System.Xml.Linq.XElement GetElement(this System.Xml.Linq.XContainer doc, string name)
        {
            var element = doc.Element(name);
            if (element == null)
                throw new ApplicationException("Missing element: " + name);
            return element;
        }
