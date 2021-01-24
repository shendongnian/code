    public class MyClass
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
    }
    
    var c = new MyClass();
    MyCheckMethod(() => c.Prop1, value => c.Prop1 = value);
