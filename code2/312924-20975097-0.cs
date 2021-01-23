    namespace MyProject
    {
        using System.IO;
        using System.Text;
        using System.Xml;
        using System.Xml.Serialization;
    
        public static class Serializer
        {
            #region Public Methods and Operators
    
            /// <summary>
            ///     Deserializes Xml string of type T.
            /// </summary>
            /// <typeparam name="T">Datatype T.</typeparam>
            /// <param name="XmlString">Input Xml string from which to read.</param>
            /// <returns>Returns rehydrated object of type T.</returns>
            public static T DeserializeXmlString<T>(string xmlString)
            {
                T tempObject;
    
                using (var memoryStream = new MemoryStream(StringToUTF8ByteArray(xmlString)))
                {
                    var xs = new XmlSerializer(typeof(T));
                    tempObject = (T)xs.Deserialize(memoryStream);
                }
    
                return tempObject;
            }
    
            /// <summary>
            ///     Serializes an object to Xml as a string.
            /// </summary>
            /// <typeparam name="T">Datatype T.</typeparam>
            /// <param name="toSerialize">Object of type T to be serialized.</param>
            /// <returns>Xml string of serialized type T object.</returns>
            public static string SerializeToXmlString<T>(T toSerialize)
            {
                string xmlstream;
    
                using (var memstream = new MemoryStream())
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    var xmlWriter = new XmlTextWriter(memstream, Encoding.UTF8);
    
                    xmlSerializer.Serialize(xmlWriter, toSerialize);
                    xmlstream = UTF8ByteArrayToString(((MemoryStream)xmlWriter.BaseStream).ToArray());
                }
    
                return xmlstream;
            }
    
            #endregion
    
            #region Methods
    
            private static byte[] StringToUTF8ByteArray(string xmlString)
            {
                return new UTF8Encoding().GetBytes(xmlString);
            }
    
            private static string UTF8ByteArrayToString(byte[] arrBytes)
            {
                return new UTF8Encoding().GetString(arrBytes);
            }
    
            #endregion
        }
    }
