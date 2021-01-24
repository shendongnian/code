      using System;
      using System.Text;
      using System.IO;
      using System.Runtime.Serialization.Formatters;
      using System.Runtime.Serialization.Formatters.Soap;
      namespace BLAST.Injection
      {
         public class XMLUtil
         {
            public static Byte[] StringToUTF8ByteArray(String xmlString)
            {
               return new UTF8Encoding().GetBytes(xmlString);
            }
            public static String SerializeToXML<T>(T objectToSerialize)
            {
               using (MemoryStream ms = new MemoryStream())
               using (StreamWriter sw = new StreamWriter(ms, Encoding.UTF8))
               {
                  SoapFormatter soapFormatter = new SoapFormatter();
                  soapFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                  soapFormatter.Serialize(ms, objectToSerialize);
                  String decoded = Encoding.UTF8.GetString(ms.ToArray());
                  return decoded;
               }
            }
            public static T DeserializeFromXML<T>(string xmlString) where T : class
            {
               T retval = default(T);
               using (MemoryStream stream = new MemoryStream(StringToUTF8ByteArray(xmlString)))
               {
                  SoapFormatter soapFormatter = new SoapFormatter();
                  soapFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                  retval = soapFormatter.Deserialize(stream) as T;
               }
               return retval;
            }
         }
      }
