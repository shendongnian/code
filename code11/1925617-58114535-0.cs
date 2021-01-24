    dynamic expandoObject = JsonConvert.DeserializeObject<ExpandoObject>(@"{
    		""IndexId"": ""dummyindex"",
    		""Id"": ""0c2d48bd-6842-4f15-b7f2-57fa259b0642"",
    		""UserId"": ""dummy_user_1"",
    		""Country"": ""dummy_stan""
    	}
    ");
    
    Type t = expandoObject.GetType();
    PropertyInfo[] properties = t.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    foreach (PropertyInfo property in properties)
    {
    	Console.WriteLine(property.ToString());
    }
