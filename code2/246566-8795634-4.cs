    [ConfigurationCollection(typeof(ElementBaseConfig), CollectionType=ConfigurationElementCollectionType.BasicMap)]
    public class MyTypesConfigCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            // Not used but function must be defined
            return null;
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return element;
        }
        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            switch (elementName)
            {
                case "mytype1":
                    return new MyType1Config();
                case "mytype2":
                    return new MyType2Config();
                default:
                    throw new ConfigurationErrorsException(
                        string.Format("Unrecognized element '{0}'.", elementName));
            }
        }
        protected override bool IsElementName(string elementName)
        {
            // Required to be true
            return true;
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
    }
