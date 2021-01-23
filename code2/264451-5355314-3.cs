    foreach (var property in trp.GetType().GetProperties()) //class ->typeof(Transport).GetProperties()
    {
        foreach (XMLAttributeProperty att in property.GetCustomAttributes(typeof(XMLAttributeProperty), true).Cast<XMLAttributeProperty>())
        {
            Log.Level0(string.Format("Property {0}, {1}={2}", property.Name, att.Name, att.Value));
            var fieldInElement = el.Descendants(property.Name).FirstOrDefault();
            if (fieldInElement != null)
            {
                try
                {
                    fieldInElement.Add(new XAttribute(att.Name, att.Value));
                }
                catch { }
            }
        }
    }
