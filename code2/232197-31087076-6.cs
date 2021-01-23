     public class IceCream: INotifyPropertyChanged
    {
        private int liczba;
        public int Liczba
        {
            get { return liczba; }
            set { liczba = value;
            Zmiana("Liczba");
            }
        }
        public IceCream(){}
    //in the same class implement the below-it will be responsible for track a changes
        public event PropertyChangedEventHandler PropertyChanged;
        private void Zmiana(string propertyName) 
        {
            if (PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
