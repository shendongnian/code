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
            timer.Enabled = true;
        }
        private void TimerTicked( object sender, EventArgs e )
        {
            StatusText = "origin";
            StatusColor = originColor;
            // Fire property changed to notify view updating data.
            PropertyChanged( this, new PropertyChangedEventArgs( StatusText ) );
            PropertyChanged( this, new PropertyChangedEventArgs( StatusColor ) );
        }
