    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string jsonData = "{\"results\":[{\"messageId\":\"15712480583306574\",\"to\":\"\",\"from\":\"TestServer\",\"sentAt\":\"2019-10-16T17:47:38.368+0000\",\"doneAt\":\"2019-10-16T17:47:38.370+0000\",\"smsCount\":1,\"mccMnc\":\"null\",\"price\":{\"pricePerMessage\":0.0,\"currency\":\"USD\"},\"status\":{\"groupId\":5,\"groupName\":\"REJECTED\",\"id\":8,\"name\":\"REJECTED_PREFIX_MISSING\",\"description\":\"Number prefix missing\"},\"error\":{\"groupId\":0,\"groupName\":\"OK\",\"id\":0,\"name\":\"NO_ERROR\",\"description\":\"No Error\",\"permanent\":false}}]}";
    		JObject jObject = JObject.Parse(jsonData);
    		
    		Console.WriteLine(jObject.SelectToken("results[0].status"));
    	}
    }
