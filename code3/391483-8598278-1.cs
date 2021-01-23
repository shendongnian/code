    public interface InterfaceA<T> where T : InterfaceB
    {
        string x {get;set;}
        IEnumerable<T> DetailList { get; set; }
    }
    
    public interface InterfaceB
    {
        int z { get; }
        int y { get; }
    }
    public class ClassB : InterfaceB
    {
        public int z { get; private set; }
        public int y { get; private set; }
    }
    public class ClassA : InterfaceA<ClassB>
    {
        public int z { get; private set; }
        public string x { get; set; }
        public IEnumerable<ClassB> DetailList {get;set;} 
    }
