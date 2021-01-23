    class Person : INotifyPropertyChanged
    {
        private int _rokurodzenia;
        public int Rokurodzenia 
        {
            get
            {
                return _rokurodzenia;
            }
            set
            {
                _rokurodzenia = value;
                Zmiana("Rokurodzenia");
            }
        }
        public Person() {rokurodzenia = 0; }
        public Person(int rokurodzenia) 
        {
            this._rokurodzenia = rokurodzenia;
        }
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
