    private WeakReference _valueReference = new WeakReference(null);
    private object _locker = new object();
  
    public MyType Value
    {    
      get
      {    
        lock(_locker)  // also provides the barriers
        {
            value _valueReference.Target;
            if (!_valueReference.IsAlive)
            {
                _valueReference = new WeakReference(value = InitializeMyType());
            }
            return value; 
        }
      }    
    }
