    public class ExternalResourceHandler
    {
        private readonly ExternalResource _resource;
        private readonly object _sync = new object();
        
        // constructors
        // ...
        // other methods
        
        public void PerformExternalOperation()
        { 
            lock(_sync)
            {
            
                Result result = _resource.Execute();
                
                // do soemthing with the result
            }
        }
    }
    
