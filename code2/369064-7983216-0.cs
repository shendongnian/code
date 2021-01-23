    public class ImportConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("importMap")]
        public ImportMapElementCollection ImportMap
        {
            get
            {
                return this["importMap"] as ImportMapElementCollection;
            }
        }
    }
    public class ImportColumnMapElement : ConfigurationElement
    {
        [ConfigurationProperty("localName", IsRequired = true, IsKey = true)]
        public string LocalName
        {
            get
            {
                return this["localName"] as string;
            }
            set
            {
                this["localName"] = value;
            }
        }
        [ConfigurationProperty("sourceName", IsRequired = true)]
        public string SourceName
        {
            get
            {
                return this["sourceName"] as string;
            }
            set
            {
                this["sourceName"] = value;
            }
        }
    }
    public class ImportMapElementCollection : ConfigurationElementCollection
    {
        public ImportColumnMapElement this[object key]
        {
            get
            {
                return base.BaseGet(key) as ImportColumnMapElement;
            }
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }
        protected override string ElementName
        {
            get
            {
                return "columnMap";
            }
        }
        protected override bool IsElementName(string elementName)
        {
            bool isName = false;
            if (!String.IsNullOrEmpty(elementName))
                isName = elementName.Equals("columnMap");
            return isName;
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new ImportColumnMapElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ImportColumnMapElement)element).LocalName;
        }
    }
