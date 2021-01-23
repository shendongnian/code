    class OutsideBoard : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private void FirePropertyChanged (string property) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        // the click- EventHandler of your UserControl
        public event Click_EventHandler (object sender, RoutedEventArgs e) {
            // your clicking code of your UserControl
            FirePropertyChanged("SuperClick");
        }
        // rest of the code inhere ...
    }
