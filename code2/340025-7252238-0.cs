    public class MyService : IMyContract
    {
        public void DoSomething(string p1, int p2)
        {
            DoThing(p1);
            DoAnotherThing(p2);
        }
    }
