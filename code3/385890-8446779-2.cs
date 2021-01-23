    public class MyService
    {
        // injected dependency
        public IMyConstants MyConstants { get; set; }
        public MyMethod(){
            // get your query...
            var query = IMyConstants.Query;
        }
    }
