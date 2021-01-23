     public static T GetObjectFromXmlString<T>(string xml)
            {
                T result = default(T);
    
                if (string.IsNullOrEmpty(xml))
                    return result;
    
               using (StringReader sr = new StringReader(xml))
               {
                   using (XmlTextReader xr = new XmlTextReader(sr))
                   {
                       XmlSerializer serializer = new XmlSerializer(typeof(T));
                       result = (T)serializer.Deserialize(xr);
    
                   }                   
               }
               
              return result;
            }
