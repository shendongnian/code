    /// <summary>
            /// The <see cref="MyProperty" /> property's name.
            /// </summary>
            public const string MyPropertyPropertyName = "MyProperty";
    
            private bool _myProperty = false;
    
            /// <summary>
            /// Gets the MyProperty property.
            /// TODO Update documentation:
            /// Changes to that property's value raise the PropertyChanged event. 
            /// This property's value is broadcasted by the Messenger's default instance when it changes.
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
    
                    var oldValue = _myProperty;
                    _myProperty = value;
    
                    // Remove one of the two calls below
                    throw new NotImplementedException();
    
                    // Update bindings, no broadcast
                    RaisePropertyChanged(MyPropertyPropertyName);
    
                    // Update bindings and broadcast change using GalaSoft.MvvmLight.Messenging
                    RaisePropertyChanged(MyPropertyPropertyName, oldValue, value, true);
                }
            }
