    public class MyElementCollection : ConfigurationElementCollection
    {
        const string ELEMENT1 = "Element1";
        const string ELEMENT2 = "Element2";
        protected override ConfigurationElement CreateNewElement ()
        {
            return new MyElement (this);
        }
        protected override object GetElementKey (ConfigurationElement element)
        {
            return ((MyElement)element).Key;
        }
        protected override bool OnDeserializeUnrecognizedElement (string elementName, XmlReader reader)
        {
            if (elementName == ELEMENT1 || elementName == ELEMENT2 {
                var myElement = new MyElement (this);
                switch (elementName) {
                case ELEMENT1:
                    myElement.Type = MyElementType.Element1;
                    break;
                case ELEMENT2:
                    myElement.Type = MyElementType.Element2;
                    break;
                }
                myElement.DeserializeElementForConfig (reader, false);
                BaseAdd (myElement);
                return true;
            }
            return false;
        }
    }
