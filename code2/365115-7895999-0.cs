        class Program
    {
        private object _parameter;
        static void Main(string[] args)
        {
            var test = new MyEventTriggeringClass();
            var eventSource = new EventSource();
            test.Attach(eventSource, "SomeEvent", "Hello World!");
            eventSource.RaiseSomeEvent();
        }
    }
    class MyEventTriggeringClass
    {
        private object _parameter;
        public void Attach(object eventSource, string eventName, object parameter)
        {
            _parameter = parameter;
            var sink = new DynamicMethod(
                "sink",
                null,
                new[] { typeof(object), typeof(object), typeof(EventArgs) },
                typeof(Program).Module);
            var ilGenerator = sink.GetILGenerator();
            var targetMethod = GetType().GetMethod("TargetMethod", BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Call, targetMethod);
            ilGenerator.Emit(OpCodes.Ret);
            var eventInfo = typeof(EventSource).GetEvent("SomeEvent");
            var handler = (EventHandler)sink.CreateDelegate(eventInfo.EventHandlerType, this);  // <-- SOLUTION!
            eventInfo.AddEventHandler(eventSource, handler);
        }
        public void TargetMethod()
        {
            Console.WriteLine("Value of _parameter = " + _parameter);
        }
    }
    class EventSource
    {
        public event EventHandler SomeEvent;
        public void RaiseSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent(this, new EventArgs());
        }
    }
