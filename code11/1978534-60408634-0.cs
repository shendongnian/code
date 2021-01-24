    public static Dictionary<string, object> ParseXml(XDocument xd)
        {
            var namespaceM = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";
            var namespaceD = "http://schemas.microsoft.com/ado/2007/08/dataservices";
            var ret = new Dictionary<string, object>();
            var propertiesElement = xd.Descendants(XName.Get("properties", namespaceM)).FirstOrDefault();
            if (propertiesElement != null)
            {
                var propertyElements = propertiesElement.Descendants();
                foreach (var propertyElement in propertyElements)
                {
                    var name = propertyElement.Name.LocalName;
                    var value = propertyElement.Value;
                    var typeAttr = propertyElement.Attribute(XName.Get("type", namespaceM));
                    var nullAttr = propertyElement.Attribute(XName.Get("null", namespaceM));
                    if (nullAttr != null && nullAttr.Value == "true")
                    {
                        ret.Add(name, null);
                    }
                    else if (typeAttr != null)
                    {
                        switch (typeAttr.Value)
                        {
                            case "Edm.Int16":
                                ret.Add(name, Convert.ToInt16(value));
                                break;
                            case "Edm.Int32":
                                ret.Add(name, Convert.ToInt32(value));
                                break;
                            case "Edm.DateTime":
                                ret.Add(name, Convert.ToDateTime(value));
                                break;
                            case "Edm.Guid":
                                ret.Add(name, Guid.Parse(value));
                                break;
                        }
                    }
                    else
                    {
                        ret.Add(name, value);
                    }
                }
            }
            return ret;
        }
