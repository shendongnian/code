    public enum MyElementType
    {
        Element1,
        Element2,
    }
    public class MyElement : ConfigurationElement
    {
        const string NAME = "name";
        const string VALUE = "value";
        const string FORMAT = "format";
        // keys should be unique, current collection count will do
        // the trick without introducing artificial keys
        public MyElement (ConfigurationElementCollection collection)
        {
            Key = collection.Count;
        }
        // note that this is not ConfigurationProperty
        public int Key { get; private set; }
        // note that this is not ConfigurationProperty
        public MyElementType Type { get; set; }
        [ConfigurationProperty(NAME)]
        public string Name {
            get { return (string)this [NAME]; }
        }
        [ConfigurationProperty(VALUE)]
        public string Value {
            get { return (string)this [VALUE]; }
        }
        [ConfigurationProperty(FORMAT)]
        public string Format {
            get { return (string)this [FORMAT]; }
        }
        // This is called when framework needs a copy of the element,
        // but it knows only about properties tagged with ConfigurationProperty.
        // We override this to copy our Key and Type, otherwise they will
        // have default values.
        protected override void Reset (ConfigurationElement parentElement)
        {
            base.Reset (parentElement);
            var myElement = (MyElement)parentElement;
            Key = myElement.Key;
            Type = myElement.Type;
        }
        // original ConfigurationElement have this protected,
        // redeclaring as protected internal to call it from collection class
        protected internal void DeserializeElementForConfig (XmlReader reader, bool serializeCollectionKey)
        {
            DeserializeElement (reader, serializeCollectionKey);
        }
    }
