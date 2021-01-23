    public string Foo 
    { get { return _foo; }
      set
      {
         _foo = value;
         if (IsInitialized)
           OnClassInitialized();
      }
    } 
    
    public static event EventHandler ClassInitialized;
    
    private OnClassInitialized()
    {
       if (ClassInitialized != null)
          ClassInitialized(this, EventArgs.Empty);
    } 
