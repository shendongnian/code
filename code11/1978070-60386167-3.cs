        public ICommand ChangeColorCommand
        {
            get
            {
                return new RelayCommand( ChangeColorAndMessage );
            }
        }
        // This is your view model constructor
        private void ViewModelCtor(){
           // your initialize code here
            //subscribe event once
            timer = new Timer();
            timer.Interval=1000;
            timer.AutoReset=false;
            timer.Elapsed += TimerTicked;
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
