    private static Outer Deserialize(XDocument serialized)
    {
        if (serialized.Root == null)
        {
            return null;
        }
        
        var outerElement = serialized.Root.Element("Outer");
        if (outerElement == null)
        {
            return null;
        }
    
        return new Outer
                   {
                       ID =
                           int.Parse(
                               outerElement.Attribute("id").Value),
                       Dict =
                           outerElement.Element("Dict").
                               Elements("Entry").ToDictionary(
                                   k => k.Attribute("key").Value,
                                   v => new Inner
                                        {
                                           Number = Convert.ToInt32(v.Attribute("number").Value),
                                           NotNumber = v.Attribute("notNumber").Value
                                        })
                   };
    }
