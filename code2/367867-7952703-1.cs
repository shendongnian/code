    public class Person : INotifyPropertyChanged
    {
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private string givenNames;
        public string GivenNames
        {
            get { return givenNames; }
            set
            {
                if (value != givenNames)
                {
                    givenNames = value;
                    OnPropertyChanged("GivenNames");
                    OnPropertyChanged("FullName");
                }
            }
        }
    }
