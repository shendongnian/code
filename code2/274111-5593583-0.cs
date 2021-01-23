    initResult.SelectMany(ir =>
           {   
               if (ir != null)
               {
                 return connectResult;
               }
               Console.WriteLine("Initialization failed thus connection failed.");
               return Observable.Throw(new Exception("Some Exception"));
           })
           .Subscribe(cr =>
               {
                  Console.WriteLine(cr != null
                     ? "Connection succeeded." 
                     : "Connection failed.");
               })
