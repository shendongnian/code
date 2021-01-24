          /// <summary>
            /// The <see cref="MyProperty" /> property's name.
            /// </summary>
        public const string MyPropertyPropertyName = "MyProperty";
        private bool _myProperty = false;
        /// <summary>
        /// Sets and gets the MyProperty property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool MyProperty
        {
            get
            {
                return _myProperty;
            }
            set
            {
                if (_myProperty == value)
                {
                    return;
                }
                _myProperty = value;
                RaisePropertyChanged(MyPropertyPropertyName);
            }
        }
