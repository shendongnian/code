    public static string JsonSerialize(Type type, object objectGraph)
            {
                MemoryStream memoryStream = new MemoryStream();
    
                try
                {
                    System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(type);
                    serializer.WriteObject(memoryStream, objectGraph);
                    return Encoding.Default.GetString(memoryStream.ToArray());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (memoryStream != null) memoryStream.Close();
                }
            }
