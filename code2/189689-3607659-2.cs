    public class TestClass
    {
        public void TestMethod()
        {
            ProcessCommand(() => MethodToCall());
        }
        public bool MethodToCall() { return true; }
        void ProcessCommand(Expression<Func<bool>> expression) { ... }
    }
