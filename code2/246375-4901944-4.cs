    class Program
    {
        static void Main(string[] args)
        {
            SpecialCharacters specialCharacters = new SpecialCharacters { Umlaute = "äüö" };
    
            // serialize object to xml
    
            MemoryStream memoryStreamSerialize = new MemoryStream();
            XmlSerializer xmlSerializerSerialize = new XmlSerializer(typeof(SpecialCharacters));
            XmlTextWriter xmlTextWriterSerialize = new XmlTextWriter(memoryStreamSerialize, Encoding.UTF8);
    
            xmlSerializerSerialize.Serialize(xmlTextWriterSerialize, specialCharacters);
            memoryStreamSerialize = (MemoryStream)xmlTextWriterSerialize.BaseStream;
    
            // converts a byte array of unicode values (UTF-8 enabled) to a string
            UTF8Encoding encodingSerialize = new UTF8Encoding();
            string serializedXml = encodingSerialize.GetString(memoryStreamSerialize.ToArray());
    
            xmlTextWriterSerialize.Close();
            memoryStreamSerialize.Close();
            memoryStreamSerialize.Dispose();
    
            // deserialize xml to object
    
            // converts a string to a UTF-8 byte array.
            UTF8Encoding encodingDeserialize = new UTF8Encoding();
            byte[] byteArray = encodingDeserialize.GetBytes(serializedXml);
    
            using (MemoryStream memoryStreamDeserialize = new MemoryStream(byteArray))
            {
                XmlSerializer xmlSerializerDeserialize = new XmlSerializer(typeof(SpecialCharacters));
                XmlTextWriter xmlTextWriterDeserialize = new XmlTextWriter(memoryStreamDeserialize, Encoding.UTF8);
    
                SpecialCharacters deserializedObject = (SpecialCharacters)xmlSerializerDeserialize.Deserialize(xmlTextWriterDeserialize.BaseStream);
            }
        }
    }
    
    [Serializable]
    public class SpecialCharacters
    {
        public string Umlaute { get; set; }
    }
