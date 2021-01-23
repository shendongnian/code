    public class MyClass {
        public MyClass() { }
        [Inject]
        public ITest Test { get; set; }
    }
    public class MyClass {
        [Inject] private ITest _test;
        public MyClass() { }
    }
