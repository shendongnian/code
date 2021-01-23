    public string Foo
    {
       get { return _Model.Foo; }
       set
       {
          if (value != _Model.Foo)
          {
             _Model.Foo = value;
             OnPropertyChanged("Foo");
          }
       }
    }
