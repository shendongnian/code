    void Main()
    {
    	//Example 1
    	var t = "{\"x\":57,\"y\":57.0,\"z\":\"Yes\"}";
    	var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(t); 
    	var f = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
    	Console.WriteLine(f);
    	//Example 2
    	JToken jt = JToken.Parse(t);
    	string formatted = jt.ToString(Newtonsoft.Json.Formatting.Indented);
    	Console.WriteLine(formatted);
    	//Example 2 in one line -
    	Console.WriteLine(JToken.Parse(t).ToString(Newtonsoft.Json.Formatting.Indented));
    }
