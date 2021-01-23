        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            // Uncomment this to catch attempts to modify UI properties from a non-UI thread
            //bool oopsie = false;
            //if (Thread.CurrentThread != Application.Current.Dispatcher.Thread)
            //{
            //    oopsie = true; // place to set a breakpt
            //}
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
