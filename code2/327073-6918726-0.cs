    class XY: INotifyPropertyChanged
    {
        public X { get {...} set { _x = value; PropertyChanged("X"); }}
        // implementation of interface...
    }
    
    class Foo
    {
         public Foo(XY xy)
         {
              this._xy = xy;
              this._xy.PropertyChanged += delegate { Console.WriteLine("changed"); }
         }
    }
