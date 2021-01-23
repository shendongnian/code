    PropertyChanged(this, new PropertyChangedEventArgs("Result1"));
    private double _length1;
    public double Length1 {
       get { return _length1; }
       set {
           _length = value;  
           PropertyChanged(this, new PropertyChangedEventArgs("Result1"));
           PropertyChanged(this, new PropertyChangedEventArgs("Result2"));
           PropertyChanged(this, new PropertyChangedEventArgs("Length1"));
       }
