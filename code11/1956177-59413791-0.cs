    public class Thing1 : IThing
    {
        public string Name { get; } = "Thing 1";
        // More const fields here.
    }
    
    public class Thing2 : IThing
    {
        public string Name { get; } = "Thing 2";
        // More fields here.
    }
    
    interface IThing 
    {   
        string Name { get; }
    }
