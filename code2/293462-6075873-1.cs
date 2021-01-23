    public static string GetSomeSetting(string settingName)
            {
                var valueToGet = string.Empty;
                var reader = XmlReader.Create("XMLFileInYourRoot.Config");
                reader.MoveToContent();
    
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "add")
                    {
                        if (reader.HasAttributes)
                        {
                            valueToGet = reader.GetAttribute("key");
                            if (!string.IsNullOrEmpty(valueToGet) && valueToGet == setting)
                            {
                                valueToGet = reader.GetAttribute("value");
                                return valueToGet;
                            }
                        }
                    }
                }
    
                return valueToGet;
            }
