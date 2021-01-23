    public string SomeProperty
    {
         get { reutrn _model.SomeProperty; }
         set {
               _model.OtherProperty = value; 
               RaisePropertyChanged("SomeProperty");
             }
    }
