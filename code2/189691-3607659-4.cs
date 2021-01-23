    public class CallingClass
    {
        public void TestMethod()
        {
            var calledClass = new CalledClass();
            ProcessCommand(() => calledClass.MethodToCall());
        }
        void ProcessCommand(Expression<Func<bool>> expression) { ... }
    }
    public class CalledClass
    {
        public bool MethodToCall() { return true; }
    }
