    public interface MyInterface2
    {
        public IList<MyInterface1> Prop2 { get; set; }
    }
    public class MyClass2 : MyInterface2
    {
        public IList<MyInterface1> Prop2 { get; set; }
    }
