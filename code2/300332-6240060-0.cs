    public interface IDoSomeActionParameters
    {
        string A { get; }
        string B { get; }
        DateTime C { get; }
        OtherEnum D { get; }
        string E { get; }
        string F { get; }              
    }
    public class DoSomeActionParameters: IDoSomeActionParameters
    {
        public string A { get; set; }
        public string B { get; set; }
        public DateTime C { get; set; }
        public OtherEnum D { get; set; }
        public string E { get; set; }
        public string F { get; set; }        
    }
