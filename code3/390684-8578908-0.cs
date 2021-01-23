        public static XElement SafeElement(this XContainer container, string name)
        {
            return container.Element(name) ?? new XElement(name);
        }
        public static XAttribute SafeAttribute(this XElement element, string name)
        {
            return element.Attribute(name) ?? new XAttribute(name, "");
        }
