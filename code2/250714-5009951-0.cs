        readonly Property<int> _myInt = new Property<int>();
        public Vector3D MyInt
        {
            get { return _myInt.GetValue(); }
            set { _MyInt.SetValue( value,
                ( oldValue, newValue ) =>
                {
                    IsDirty = true;
                } ); 
            }
        }
