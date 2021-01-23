    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    
    public static class XsdObjectSerializer {
        #region Public Methods
        public static String ToXsdSerializedXmlDocument<T>(this T t) {
            using (var customUtf8TextWriter = new CustomUtf8StringWriter()) {
                using (var customXmlTextWriter = new CustomXmlTextWriter(customUtf8TextWriter)) {
                    customXmlTextWriter.Formatting = Formatting.Indented;
                    new XmlSerializer(typeof(T)).Serialize(customXmlTextWriter, t);
                }
                var xsdSerializedXmlDocument = customUtf8TextWriter.ToString();
                return xsdSerializedXmlDocument;
            }
        }
        #endregion
    
        #region Private Classes
        private class CustomUtf8StringWriter : StringWriter {
            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }
    
        private class CustomXmlTextWriter : XmlTextWriter {
            public CustomXmlTextWriter(TextWriter textWriter) : base(textWriter) { }
            public CustomXmlTextWriter(Stream stream, Encoding encoding) : base(stream, encoding) { }
            public CustomXmlTextWriter(string filename, Encoding encoding) : base(filename, encoding) { }
            public override void WriteString(string text) {
                if (String.IsNullOrEmpty(text))
                    return;
    
                const string SpecialChars = @"<>&";
                if (text.IndexOfAny(SpecialChars.ToCharArray()) != -1) {
                    WriteCData(text);
                } else {
                    base.WriteString(text);
                }
            }
        }
        #endregion
    }
