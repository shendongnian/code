    public class Hello {
        public string Name { get; set; }
    }
    
    public class HelloResponse {
        public string Result { get; set; }
    }
    public class HelloService : IService<Hello> {
        public object Execute(Hello request)
        {
            var dto = new HelloResponse { Result = "Hello, " + request.Name };
    	    return new HttpResult(dto) {
    		{ "Access-Control-Allow-Origin", "*" },
    		{ "Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS" },
    	    };
        }
    }
