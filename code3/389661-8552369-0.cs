    class PersonModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value; <---- set breakpoint here
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
    }
