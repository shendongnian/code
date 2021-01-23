    public double Length1 {
       get { return _length1; }
       set {
           _length = value;  
           RaiseThese("Result1", "Result2", "Length1");
       }
