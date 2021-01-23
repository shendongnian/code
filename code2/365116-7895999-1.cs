        class Program
    {
        private object _parameter;
        static void Main(string[] args)
        {
            var test = new MyEventTriggeringClass();
            var eventSource = new EventSource();
            test.Attach(eventSource, "SomeEvent", "Hello World!");
            eventSource.RaiseSomeEvent();
            Console.ReadLine();
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
            var eventInfo = typeof(EventSource).GetEvent("SomeEvent");
            var ilGenerator = sink.GetILGenerator();
            var targetMethod = GetType().GetMethod("TargetMethod", BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null);
            ilGenerator.Emit(OpCodes.Ldarg_0); // <-- loads 'this' (when sink is not static)
            ilGenerator.Emit(OpCodes.Call, targetMethod);
            ilGenerator.Emit(OpCodes.Ret);
            // SOLUTION: pass 'this' as the delegate target...
            var handler = (EventHandler)sink.CreateDelegate(eventInfo.EventHandlerType, this);
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
