    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                ElementX elementX = new ElementX()
                {
                    ElementYNames = new ElementY[] {
                        new ElementY() {
                            FieldAmount =  new ElementYFieldAmountType() {
                                Amt = new FieldAmount() {
                                   Ccy = "VALUR",
                                   Value = 123.456M
                                }
                            },
                            Field1 = "a",
                            Field2 = "b",
                            Field3 = "c"
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(ElementX));
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add("ac", "http://www.example.org/Standards/xyz/1");
                namespaces.Add("rlc", "http://www.example.org/Standards/def/1");
                namespaces.Add("def1", "http://www.lol.com/Standards/lol.xsd");
                string xml = Test.SerializeAsUtf8<ElementX>(serializer, elementX, namespaces);
            }
        }
        public static class Test
        {
            public static string SerializeAsUtf8<T>(this XmlSerializer serializer, T o, XmlSerializerNamespaces ns)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                StringWriter writer = new StringWriter();
                using (XmlWriter xWriter = XmlWriter.Create(writer, settings))
                {
                    serializer.Serialize(xWriter, o, ns);
                    return writer.ToString();
                }
            }
        }
        [XmlRoot(Namespace = "http://www.example.org/Standards/def/1")]
        public partial class ElementX
        {
            [XmlElement("ElementYName")]
            public ElementY[] ElementYNames { get; set; }
        }
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.example.org/Standards/xyz/1")]
        public partial class ElementY
        {
            [XmlAttribute]
            public string Field1 { get; set; }
            public ElementYFieldAmountType FieldAmount { get; set; }
            public string Field2 { get; set; }
            private string field3;
            /// <remarks/>
            public string Field3
            {
                get
                {
                    return this.field3;
                }
                set
                {
                    this.field3 = value;
                }
            }
        }
        [Serializable]
        [XmlRoot("code")]
        [XmlType(AnonymousType = true, Namespace = "http://www.example.org/Standards/xyz/1")]
        public class ElementYFieldAmountType
        {
            public FieldAmount Amt { get; set; }
        }
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.example.org/Standards/xyz/1")]
        public class FieldAmount
        {
            private string _ccyField;
            private decimal valueField;
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Ccy
            {
                get
                {
                    return this._ccyField;
                }
                set
                {
                    this._ccyField = value;
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public decimal Value
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
        }
    }
