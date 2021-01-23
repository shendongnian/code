    T ConvertObject<T>(object M) where T : class
    {
        // Serialize the original object to json
       // Desarialize the json object to the new type 
     var obj = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(M));
     return obj;
    } 
    // Test ObjectToCast is type Namespace1.Class, obj is Namespace2 
     Namespace2.Class obj = ConvertObject<Namespace2.Class>(ObjectToCast);
