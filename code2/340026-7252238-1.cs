    // decorate your class like this
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class MyService : IMyContract
    {
        // these fields will persist until the session is closed
        private string _p1;
        private int _p2;
        public void DoSomething(string p1, int p2)
        {
            _p1 = p1;
            _p2 = p2;         
        }
        // check that the _p1 and _p2 values are initialised before use
        public void AnotherServiceOperation()
        {
            DoThing(_p1);
            DoAnotherThing(_p2);
        }
    }
