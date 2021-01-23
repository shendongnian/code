    public class Level : IDisposable
    {
        private bool disposing = false;
        public Level() { }
    
        public void Foo()
        {
            if (disposing)
                return;
            MessageBox.Show("foo");
        }
    
        public void Dispose()
        {
            if (disposing)
                return;
            disposing = true;
        }
    }
