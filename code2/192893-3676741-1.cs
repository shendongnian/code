    public class MyClass2 : IMyInterface2
    {
        public string prop1 { get; set; }
        public IList<MyClass1> prop2 { get; set; }
        public IList<IMyInterface1> IMyInterface2.prop2
        {
            get { return prop2.Cast<IMyInterface1>.ToList(); }
            set { prop2 = value.Cast<MyClass1>().ToList(); }
        }
    }
