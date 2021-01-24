    string[] parameterNames = new string[] { "Test1", "Test2", "Test3" };
    
    JArray jarrayObj = new JArray();
    
    foreach (string parameterName in parameterNames)
    {
        jarrayObj.Add(parameterName);
    }
    
    string bDay = "2011-05-06";
    string email = "dude@test.com";
    
    JObject UpdateTestProfile = new JObject(
                                   new JProperty("_delete", jarrayObj),
                                   new JProperty("birthday", bDay),
                                   new JProperty("email", email));
    
    Console.WriteLine(UpdateTestProfile.ToString());
