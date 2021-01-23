    class MyProgram {
    	struct MyObj {
    		public string test { get; set; }
    	}
    
    	static void Main(string[] args) {
    		var json_serializer = new JavaScriptSerializer();
    		MyObj routes_list = json_serializer.Deserialize<MyObj>("{ \"test\":\"some data\" }");
    		Console.WriteLine(routes_list.test);
    
    		Console.WriteLine("Done...");
    		Console.ReadKey(true);
    	}
    }
