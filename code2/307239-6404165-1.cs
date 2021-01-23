    class Whatever : NotificationObject
    {
        private string _foo = String.Empty;
        public string Foo
        {
            get { return _foo ?? String.Empty; }
            set
            {
                if( !_foo.Equals( value ) )
                {
                    _foo = value;
                    RaisePropertyChanged( this.Foo );
                }
            }
        }
    }
