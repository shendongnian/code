    public class Animals : INotifyPropertyChanged
    {
        int numberOfElephants;
        int numberOfMonkeys;
        public int NumberOfElephants
        {
            get { return numberOfElephants; }
            set
            {
                numberOfElephants = value;
                OnPropertyChanged("TotalAnimals");
                OnPropertyChanged("NumberOfElephants");
            }
        }
        public int NumberOfMonkeys
        {
            get { return numberOfMonkeys; }
            set
            {
                numberOfMonkeys = value;
                OnPropertyChanged("TotalAnimals");
                OnPropertyChanged("NumberOfMonkeys");
            }
        }
        public int TotalAnimals
        {
            get { return NumberOfElephants + NumberOfMonkeys; }
        }
        public virtual void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
