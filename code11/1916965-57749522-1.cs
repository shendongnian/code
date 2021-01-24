    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                StreamReader sReader = new StreamReader(FILENAME);
                //read past the unicode in first line
                sReader.ReadLine();
                XmlReader reader = XmlReader.Create(sReader);
                XmlSerializer serializer = new XmlSerializer(typeof(ResponseDoc));
                ResponseDoc responseDoc = (ResponseDoc)serializer.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "Responses", Namespace = "")]
        public partial class ResponseDoc
        {
            private ResponseType[] responseField;
            /// <remarks/>
            [System.Xml.Serialization.XmlElement(ElementName = "Response", Namespace = "")]
            public ResponseType[] response
            {
                get
                {
                    return this.responseField;
                }
                set
                {
                    this.responseField = value;
                }
            }
        }
        [XmlRoot(ElementName = "Response", Namespace = "")]
        public partial class ResponseType
        {
            private int entitylineNumberField;
            private string statusCodeField;
            private string uid;
            private long entityMark;
            private ResponseTypeErrors[] responseTypeErrors;
            /// <remarks/>
            [XmlElement(ElementName = "inv_number", Namespace = "")]
            public string entitylineNumber
            {
                get
                {
                    return this.entitylineNumberField.ToString();
                }
                set
                {
                    this.entitylineNumberField = int.Parse(value);
                }
            }
            /// <remarks/>
            [XmlElement(ElementName = "StatusCode", Namespace = "")]
            public string statusCode
            {
                get
                {
                    return this.statusCodeField;
                }
                set
                {
                    this.statusCodeField = value;
                }
            }
            [XmlElement(ElementName = "Uid", Namespace = "")]
            public string Uid
            {
                get
                {
                    return this.uid;
                }
                set
                {
                    this.uid = value;
                }
            }
            [XmlElement(ElementName = "entityMark", Namespace = "")]
            public string EntityMark
            {
                get
                {
                    return this.entityMark.ToString();
                }
                set
                {
                    this.entityMark = long.Parse(value);
                }
            }
            [XmlElement(ElementName = "Errors", Namespace = "")]
            public ResponseTypeErrors[] Errors
            {
                get
                {
                    return this.responseTypeErrors;
                }
                set
                {
                    this.responseTypeErrors = value;
                }
            }
        }
        [XmlRoot(ElementName = "Errors", Namespace = "")]
        public partial class ResponseTypeErrors
        {
            private ErrorType[] errorField;
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Error")]
            public ErrorType[] error
            {
                get
                {
                    return this.errorField;
                }
                set
                {
                    this.errorField = value;
                }
            }
        }
        [XmlRoot(ElementName = "Error", Namespace = "")]
        public partial class ErrorType
        {
            private string messageField;
            private int codeField;
            /// <remarks/>
            [XmlElement(ElementName = "Message", Namespace = "")]
            public string message
            {
                get
                {
                    return this.messageField;
                }
                set
                {
                    this.messageField = value;
                }
            }
            /// <remarks/>
            [XmlElement(ElementName = "Code", Namespace = "")]
            public int code
            {
                get
                {
                    return this.codeField;
                }
                set
                {
                    this.codeField = value;
                }
            }
        }
    }
