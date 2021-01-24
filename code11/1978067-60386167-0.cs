        public ICommand ChangeColorCommand
        {
            get
            {
                return new RelayCommand( ChangeColorAndMessage );
            }
        }
        public void ChangeColorAndMessage( string[] args )
        {
            StatusText = "Button pressed";
            StatusColor = changedColor;
            // You implementation for changing it back.
        }
