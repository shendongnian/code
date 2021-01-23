    public static class SerialiserHelper
    {
    public static string Serialize(this object @object)
            {
                try
                {
                    
                   DataContractSerializer serializer = new DataContractSerializer(@object.GetType());
    
    
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
    
                        serializer.WriteObject(memoryStream, @object);
    
                        var encoder = new System.Text.UTF8Encoding(false);
    
                        return encoder.GetString(memoryStream.GetBuffer(), 0, Convert.ToInt32(memoryStream.Length));
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
    
    
    
            public static T DeSerialize<T>(this string serializedObject)
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
    
                var encoder = new System.Text.UTF8Encoding(false);
                    
                using (var memoryStream = new MemoryStream(encoder.GetBytes(serializedObject)))
                {   
                    return (T)serializer.ReadObject(memoryStream);
                }
            }
