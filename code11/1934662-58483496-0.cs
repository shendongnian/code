    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication137
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(data));
                data d = (data)serializer.Deserialize(reader);
            }
        }
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:tc:SPML:2:0", IsNullable = false)]
        public partial class data
        {
            private attr[] itemsField;
            /// <remarks/>
            [XmlElement(ElementName = "attr", Namespace = "urn:oasis:names:tc:DSML:2:0:core")]
            public attr[] Items
            {
                get
                {
                    return this.itemsField;
                }
                set
                {
                    this.itemsField = value;
                }
            }
        }
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:tc:DSML:2:0:core", IsNullable = false)]
        public partial class attr
        {
            private string valueField;
            private string nameField;
            /// <remarks/>
            public string value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }
    }
