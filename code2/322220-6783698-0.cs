    public class Foo : INotifyPropertyChanged
    {
        private string bar;
        private string baz;
       
        public string Bar
        {
            get { return this.bar; }
            set
            {
                this.bar = value;
                // this is where the magic of bindings happens
                this.OnPropertyChanged("Bar");
            }
        }
        // rest of the class here...
    }
    
