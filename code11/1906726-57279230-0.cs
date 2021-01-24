    public class Foo
    {
        public object DoSomething() {
            StackFrame frame = new StackFrame(1, true);
            var method = frame.GetMethod();
            var lineNumber = frame.GetFileLineNumber();
        }
    }
