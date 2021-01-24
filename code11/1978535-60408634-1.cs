    public static List<Dictionary<string, object>> ParseXml(XDocument xd)
        {
            var namespaceM = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";
            var namespaceD = "http://schemas.microsoft.com/ado/2007/08/dataservices";
            var ret = new List<Dictionary<string, object>>();
            var entryElements = xd.Descendants(XName.Get("entry", "http://www.w3.org/2005/Atom"));
            foreach (var entryElement in entryElements)
            {
                var propertiesElement = entryElement.Descendants(XName.Get("properties", namespaceM)).FirstOrDefault();
                if (propertiesElement != null)
                {
                    var dict = new Dictionary<string, object>();
                    var propertyElements = propertiesElement.Descendants();
                    foreach (var propertyElement in propertyElements)
                    {
                        var name = propertyElement.Name.LocalName;
                        var value = propertyElement.Value;
                        var typeAttr = propertyElement.Attribute(XName.Get("type", namespaceM));
                        var nullAttr = propertyElement.Attribute(XName.Get("null", namespaceM));
                        if (nullAttr != null && nullAttr.Value == "true")
                        {
                            dict.Add(name, null);
                        }
                        else if (typeAttr != null)
                        {
                            switch (typeAttr.Value)
                            {
                                case "Edm.Int16":
                                    dict.Add(name, Convert.ToInt16(value));
                                    break;
                                case "Edm.Int32":
                                    dict.Add(name, Convert.ToInt32(value));
                                    break;
                                case "Edm.DateTime":
                                    dict.Add(name, Convert.ToDateTime(value));
                                    break;
                                case "Edm.Guid":
                                    dict.Add(name, Guid.Parse(value));
                                    break;
                            }
                        }
                        else
                        {
                            dict.Add(name, value);
                        }
                    }
                    ret.Add(dict);
                }
            }
            return ret;
        }
