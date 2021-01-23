    public class BaseType {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Article { get; set; }
    }
    public class A : BaseType {
        public string Order { get; set; }
    }
    public class B : BaseType { }
    public class C : BaseType {
        public string Manufacturer { get; set; }
    }
