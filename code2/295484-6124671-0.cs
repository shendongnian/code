    public class MyClass {
        private readonly ITest _test;
        [Inject]
        public MyClass(ITest test) {
            _test = test;
        }
    }
