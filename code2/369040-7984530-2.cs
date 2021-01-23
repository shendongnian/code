    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Schema;
    namespace ConsoleApplication3
    {
        class Program
        {
            class XmlResolver : XmlUrlResolver
            {
                internal const string BaseUri = "schema://";
                public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
                {
                    if (absoluteUri.Scheme == "schema")
                    {
                        switch (absoluteUri.LocalPath)
                        {
                            case "/ADDRESS.xsd":
                                return new MemoryStream(Encoding.UTF8.GetBytes(Resource.ADDRESS));
                            case "/PERSON.xsd":
                                return new MemoryStream(Encoding.UTF8.GetBytes(Resource.PERSON));
                        }
                    }
                    return base.GetEntity(absoluteUri, role, ofObjectToReturn);
                }
            }
            static void Main(string[] args)
            {
                using (XmlReader reader = XmlReader.Create(new StringReader(Resource.PERSON), new XmlReaderSettings(), XmlResolver.BaseUri))
                {
                    XmlSchemaSet xset = RetrieveSchemaSet(reader);
                    Console.WriteLine(xset.IsCompiled);
                }
            }
            private static XmlSchemaSet RetrieveSchemaSet(XmlReader reader)
            {
                XmlSchemaSet xset = new XmlSchemaSet() { XmlResolver = new XmlResolver() };
                xset.Add(XmlSchema.Read(reader, null));
                xset.Compile();
                return xset;
            }
        }
    }
