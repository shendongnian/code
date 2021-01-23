    public INotifyPropertyChanged parent
    {
       get{return _parent;}
       set
       {
          _parent = value;
          this.PropertyChanged += _parent.RaiseChanged();
       }
    }
