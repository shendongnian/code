    JavaScriptSerializer serializer = new JavaScriptSerializer();
    Object obj = serializer.DeserializeObject("{ 'name': 'vinicius fonseca', 'age': 31 }");
    Dictionary<String, Object> ret = (Dictionary<String, Object>)obj;
    Console.WriteLine(ret["name"].GetType().Name); // Output: String
    Console.WriteLine(ret["name"].ToString()); // Output: vinicius fonseca
    Console.WriteLine(ret["age"].GetType().Name); // Output: Int32
    Console.WriteLine(ret["age"].ToString()); // Output: 31
