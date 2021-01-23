    public class DogViewModel : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                // Needed to alert WPF to a change in the data
                // which will then update the UI
                this.RaisePropertyChanged("Name");
            }
        }
        public event PropertyChangedHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
