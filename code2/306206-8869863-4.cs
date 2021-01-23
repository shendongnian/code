    public class AuthorisedClientsSection : ConfigurationSection {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public AuthorisedClientElementCollection Elements {
            get { return (AuthorisedClientElementCollection)base[""];}
        }
    }
    public class AuthorisedClientElementCollection : ConfigurationElementCollection {
        const string ELEMENT_NAME = "AuthorisedClient";
        public override ConfigurationElementCollectionType CollectionType {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        protected override string ElementName {
            get { return ELEMENT_NAME; }
        }
        protected override ConfigurationElement CreateNewElement() {
            return new AuthorisedClientElement();
        }
        protected override object GetElementKey(ConfigurationElement element) {
            return ((AuthorisedClientElement)element).Name;
        }
    }
    public class AuthorisedClientElement : ConfigurationElement {
        const string NAME = "name";
        [ConfigurationProperty(NAME, IsRequired = true)]
        public string Name {
            get { return (string)base[NAME]; }
        }
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public QueueElementCollection Elements {
            get { return (QueueElementCollection)base[""]; }
        }
    }
    public class QueueElementCollection : ConfigurationElementCollection {
        const string ELEMENT_NAME = "Queue";
        public override ConfigurationElementCollectionType CollectionType {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        protected override string ElementName {
            get { return ELEMENT_NAME; }
        }
        protected override ConfigurationElement CreateNewElement() {
            return new QueueElement();
        }
        protected override object GetElementKey(ConfigurationElement element) {
            return ((QueueElement)element).Id;
        }
    }
    public class QueueElement : ConfigurationElement {
        const string ID = "id";
        [ConfigurationProperty(ID, IsRequired = true)]
        public int Id {
            get { return (int)base[ID]; }
        }
    }
