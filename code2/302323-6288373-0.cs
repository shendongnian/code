    public class A
    {
        B _b;
        public A()
        {
            _b = new B();
            _b.DidSomething += HandleDidSomething;
        }
        private void HandleDidSomething(object source, EventArgs e)
        {
            // Handle the B did something case
        }
        public void WaitForBToFinish() { _b.DoneDoingThings.WaitOne(); }
    }
    
    public class B
    {
        Event EventHandler DidSomething;
        ManualResetEvent DoneDoingThings = new ManualResetEvent(false);
        
        public B() {}
        public void StartDoingThings()
        {
            new Thread(DoThings).Start();
        }
        private void DoThings()
        {
             for (int i=0; i < 10; i++)
             {
                 Thread.Sleep(1000);
                 OnDidSomething(new EventArgs());
             }
             DoneDoingThings.Set();
        }
        private void OnDidSomething(EventArgs e)
        {
             if (DidSomething != null)
             {
                  DidSomething(e);
             }
        }    
     }
