    using System.Xml;
    using System.Xml.Schema;
    using NUnit.Framework;
    
    namespace AYez.EmbeddedXsdTests
    {
        [TestFixture]
        public class EmbeddedXsdTests
        {
            [Test]
            public void SomeEntryPoint()
            {
                var schemaSet = new XmlSchemaSet {XmlResolver = new ResourceXmlResolver()};
                schemaSet.Add("rrn:org.xcbl:schemas/xcbl/v4_0/financial/v1_0/financial.xsd", @"Invoice.xsd");
                schemaSet.Compile();
    
                var settings = new XmlReaderSettings { ValidationType = ValidationType.Schema, Schemas = schemaSet };
    
                settings.ValidationEventHandler += delegate(object o, ValidationEventArgs e)
                {
                    switch (e.Severity)
                    {
                        case XmlSeverityType.Error:
                            Console.Write("Error: {0}", e.Message);
                            break;
                        case XmlSeverityType.Warning:
                            Console.Write("Warning: {0}", e.Message);
                            break;
                    }
                };
                var xmlReader = XmlReader.Create(@"d:\temp\Invoice.xml", settings);
                while (xmlReader.Read()) { /*TODO: Nothing*/} // Validation is performed while reading
    
            }
        }
    
        public class ResourceXmlResolver: XmlResolver
        {
            /// <summary>
            /// When overridden in a derived class, maps a URI to an object containing the actual resource.
            /// </summary>
            /// <returns>
            /// A System.IO.Stream object or null if a type other than stream is specified.
            /// </returns>
            /// <param name="absoluteUri">The URI returned from <see cref="M:System.Xml.XmlResolver.ResolveUri(System.Uri,System.String)"/>. </param><param name="role">The current version does not use this parameter when resolving URIs. This is provided for future extensibility purposes. For example, this can be mapped to the xlink:role and used as an implementation specific argument in other scenarios. </param><param name="ofObjectToReturn">The type of object to return. The current version only returns System.IO.Stream objects. </param><exception cref="T:System.Xml.XmlException"><paramref name="ofObjectToReturn"/> is not a Stream type. </exception><exception cref="T:System.UriFormatException">The specified URI is not an absolute URI. </exception><exception cref="T:System.ArgumentNullException"><paramref name="absoluteUri"/> is null. </exception><exception cref="T:System.Exception">There is a runtime error (for example, an interrupted server connection). </exception>
            public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
            {   
                    // If ofObjectToReturn is null, then any of the following types can be returned for correct processing:
                    // Stream, TextReader, XmlReader or descendants of XmlSchema
                    var result =  this.GetType().Assembly.GetManifestResourceStream(string.Format("AYez.EmbeddedXsdTests.{0}",
                                                                                                 Path.GetFileName(absoluteUri.ToString())));                
                    // set a conditional breakpoint "result==null" here
                    return result;
            }
    
            /// <summary>
            /// When overridden in a derived class, sets the credentials used to authenticate Web requests.
            /// </summary>
            /// <returns>
            /// An <see cref="T:System.Net.ICredentials"/> object. If this property is not set, the value defaults to null; that is, the XmlResolver has no user credentials.
            /// </returns>
            public override ICredentials Credentials
            {
                set { throw new NotImplementedException(); }
            }
        }
    }
