    class SomeViewModel : ViewModelBase
    {
         public string Foo
         {
             get { return this.foo; }
             set
             {
                 if (this.RaiseAcceptPendingChange("Foo", value))
                 {
                     this.RaiseNotifyPropertyChanging("Foo");
                     this.foo = value;
                     this.RaiseNotifyPropretyChanged("Foo");
                 }
             }
         }
    }
