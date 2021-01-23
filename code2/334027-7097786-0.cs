        string A { get; set; }
        IMyInterfaceB B { get; set; }
    }
    
    public interface IMyInterfaceB
    {
        string B { get; set; }
    }
    
    // POCOs
    public class pocoOneB : IMyInterfaceB
    {
        public string B { get; set; }
        public string C { get; set; }  // extending the poco with a non-interfaced property
    }
    
    public class pocoOneA : IMyInterfaceA
    {
        public string A { get; set; }
    	IMyInterfaceB IMyInterfaceA.B{ get; set; }
        public pocoOneB B { get{ return new pocoOneB(); } set{} }  // fails, can I strongly type an interface??
    }
    
    public class pocoTwoB : IMyInterfaceB
    {
        public string  B { get; set; }
        public string D { get; set; }  // extending the poco with a non-interfaced property
    }
    
    public class pocoTwoA : IMyInterfaceA
    {
        public string A { get; set; }
    	IMyInterfaceB IMyInterfaceA.B{ get; set; }
        public pocoOneB B { get{ return new pocoOneB(); } set{} }  // fails, can I strongly type an interface??
    }
