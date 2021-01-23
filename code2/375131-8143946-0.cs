        public event PropertyChangedEventHandler PropertyChanged;
     
        int _MyProperty;
        public int MyProperty
        {
            get { return _MyProperty; }
            set { ChangeIfUnequal(ref _MyProperty, value, "MyProperty"); }
        }
        int _AnotherProperty;
        public int AnotherProperty
        {
            get { return _AnotherProperty; }
            set { ChangeIfUnequal(ref _AnotherProperty, value); }
        }
        void ChangeIfUnequal<T>(ref T Val, T NewValue, string Identifier="")
        {
            if (!Val.Equals(NewValue))
            {
                Val = NewValue;
                var temp = PropertyChanged;
                if(temp != null)
                    temp(this, new PropertyChangedEventArgs(Identifier));
            }
        }
