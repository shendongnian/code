    using System.IO;
    using System.Runtime.Serialization.Json;
    
    private static string DataToJson<T>(T data)
    {
    	MemoryStream stream = new MemoryStream();
    
    	DataContractJsonSerializer serialiser = new DataContractJsonSerializer(
    		data.GetType(),
    		new DataContractJsonSerializerSettings()
    		{
    			UseSimpleDictionaryFormat = true
    		});
    
    	serialiser.WriteObject(stream, data);
    
    	return Encoding.UTF8.GetString(stream.ToArray());
    }
