    static Func<string, Tuple<string, Exception>> OperationWrapper(Func<string, string> op)
    { 
       return s => { 
           try
           { 
              return Tuple.Create<string, Exception>(op(s), null);
           }
           catch(Exception ex)
           {
              return Tuple.Create<string, Exception>(null, ex);
           }
       };
    }
    
    // goes rest of the code except changes shown below
    ...
    
    var wrapper = OperationWrapper(SomeMethodThatMightThrow);
    var exceptionDemoQuery =
            from file in files
            let n = wrapper(file)
            select n;
        
            foreach (var item in exceptionDemoQuery)
            {
                if (item.Item2 == null)
                {
                     Console.WriteLine("Processing {0}", item.Item1);
                }
                else
                { 
                     // we have exception
                     Console.WriteLine(item.Item2.Message); 
                }
            }
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
