    public class DynamicEvent
    {
        private Dictionary<int, Action<object[]>> delegates = new Dictionary<int, Action<object[]>>();
        public ScriptEngine Engine { get; set; }
        public DynamicEvent(ScriptEngine engine)
        {
            Engine = engine;
        }
 
        public void addHandler(PythonFunction pythonFunction)
        {
            int args = (int) pythonFunction.func_code.co_nlocals;
            delegates.Add(args, a => Engine.Operations.Invoke(pythonFunction, a));
        }
        public void addHandler(Delegate d)
        {
            int args = d.Method.GetParameters().Length;
            delegates.Add(args, a => d.DynamicInvoke(a));
        }
        public void invoke(params object[] args)
        {
            Action<object[]> action;
            if(!delegates.TryGetValue(args.Length, out action))
                throw new ArgumentException("There is not handler that takes " + args.Length + " arguments!");
            action(args);
        }
    }
