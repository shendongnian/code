    public void AttachToAEvent(int _bar)
    {
        Closure closure = new Closure();
        closure._bar = _bar;
        closure._bInstance = this;
        _foo.AEvent += new EventHandler(closure.Handler);
    }
    
    [CompilerGenerated]
    private sealed class Closure
    {
        public int _bar;
        public B _bInstance;
    
        public void Handler(object sender , EventArgs e)
        {
            _bInstance.UseBar(this._bar);
        }
    }
 
 
 
 
