     public T Deserialize<T>(string input) where T : class
        {
            //Init attrbibutee overrides
            XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();
            XmlAttributes attrs = new XmlAttributes();
            //Load all types which derive from GuiConfiguration base
            var guiConfTypes = (from lAssembly in AppDomain.CurrentDomain.GetAssemblies()
                                from lType in lAssembly.GetTypes()
                                where typeof(GuiConfigurationBase).IsAssignableFrom(lType) && lType != typeof(GuiConfigurationBase)
                                select lType).ToArray();
            //All classes which derive from GuiConfigurationBase
            foreach (var guiConf in guiConfTypes)
            {
                XmlElementAttribute attr = new XmlElementAttribute
                {
                    ElementName = guiConf.Name,
                    Type = guiConf
                };
                attrs.XmlElements.Add(attr);
            }
            //Add Attribute overrides for ConfigurationBase class's property GuiConfiguration
            attrOverrides.Add(typeof(ConfigurationBase), nameof(ConfigurationBase.GuiConfiguration), attrs);
            XmlSerializer ser = new XmlSerializer(typeof(T), attrOverrides);
            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }
