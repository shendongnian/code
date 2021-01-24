    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("xs", "http://www.w3.org/2001/XMLSchema");
                namespaces.Add("", "http://example.com");
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(Foo));
                Foo foo = new Foo()
                {
                    List = new FooListItem[][] {
                        new FooListItem[] { 
                            new FooListItem() { Value = "abc"},
                            new FooListItem() { Value = "abd"},
                            new FooListItem() { Value = "abe"}
                        },
                        new FooListItem[] { 
                            new FooListItem() { Value = "bbc"},
                            new FooListItem() { Value = "bbd"},
                            new FooListItem() { Value = "bbe"}
                        },
                        new FooListItem[] { 
                            new FooListItem() { Value = "cbc"},
                            new FooListItem() { Value = "cbd"},
                            new FooListItem() { Value = "cbe"}
                        }
                    }
                };
                serializer.Serialize(writer, foo, namespaces);
            }
        }
        [XmlType(Namespace = "http://example.com")]
        [XmlRoot(Namespace = "http://example.com", IsNullable = false)]
        public partial class Foo
        {
            private FooListItem[][] listField;
            [XmlArrayItem("Item", IsNullable = false)]
            public FooListItem[][] List
            {
                get
                {
                    return this.listField;
                }
                set
                {
                    this.listField = value;
                }
            }
        }
        [XmlType(Namespace = "http://example.com")]
        public partial class FooListItem
        {
            private string valueField;
            [XmlText]
            public string Value
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
