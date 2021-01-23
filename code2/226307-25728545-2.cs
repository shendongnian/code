    private class Borked
    {
        public object X 
        {
            [DebuggerStepThrough]
            get { throw new NotImplementedException(); }
        }
    }
    private void SomeMethod()
    {
        var bad = new Borked();
        object obj = bad.TryGet(o => o.X);
    }
    
