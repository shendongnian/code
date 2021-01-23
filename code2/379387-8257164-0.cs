    public class Foo
    {
        private bool disposed;
    
        public void DoSomething ()
        {
            GuardDisposed ();
        }
    
        protected void GuardDisposed ()
        {
            if (disposed)
                throw new ObjectDisposedException (GetType ().Name);
        }
    }
