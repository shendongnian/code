        public Foo CurrentFoo
        {
            get
            {
                return this.fooValue;
            }
    
            set
            {
                // Notify listeners if value is changing.
                bool bok = false;
                if (this.fooValue !=null && !this.fooValue.Equals(value))
                    bok = true;
                else if(this.fooValue ==null)
                     bok = (this.fooValue == value);
                if(bok) {
                    this.fooValue = value;
                    this.OnPropertyChanged("CurrentFoo");
                }
            }
        }
