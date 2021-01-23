    public partial class IBaseEvent
        {
            private Dictionary<int, Action> funcs = new Dictionary<int, Action>();
            public void Execute()
            {
                foreach (var func in funcs.Values)
                {
                    func();
                }
            }
    
            public void AddFunction(Type t, Action ff)
            {
                funcs.Add(t.GetHashCode(), ff);
            }
        }
    
        public class DummyEvent : IBaseEvent
        {
            private string EventType = "DUMMY_EVENT";
    
            private void DoSomething(string x)
            {
                Console.WriteLine(x);
            }
    
            public DummyEvent()
            {
                Action temp = () =>
                    {
                        DoSomething("Hello World from DummyEvent! TypeCode");
                    };
    
                AddFunction(typeof(Logging), temp);
            }
        }
