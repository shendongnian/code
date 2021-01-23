    public class MyClass
    {
        public event EventHandler MyEvent;
        public void DoSomething()
        {
            MyEvent.Raise(this, EventArgs.Empty);   
        }
    }
