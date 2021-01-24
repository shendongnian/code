    class Program {
    	LoggerConfiguration ex = null; \\ or make it public if you want to call the log outside the local class
    	
    	void Main(){
    		ex = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .Enrich.FromLogContext()
                    .WriteTo.File(string.Format("log/log-{0}.txt",DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss")), outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] ({SourceContext}.{Method}) {Message}{NewLine}{Exception}")
                    .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] ({SourceContext}.{Method}) {Message}{NewLine}{Exception}")
                    .CreateLogger();
    		Method();
    	}
    	
    	void Method() {
    		ex.WriteTo.File(string.Format("/"));
    	}
    }
