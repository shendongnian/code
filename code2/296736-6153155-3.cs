    public class Data : INotifyPropertyChanged
    {
        public List<Person> People { get; set; }
        public List<Code> Codes { get; set; }
        private Code _selectedCode;
        public Code SelectedCode
        {
            get
            {
                return _selectedCode;
            }
            set
            {
                _selectedCode = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCode"));
                SelectedPeople = People.Where(p => p.CodeId == SelectedCode.Id).ToList();
            }
        }
        private List<Person> _selectedPeople;
        public List<Person> SelectedPeople
        {
            get
            {
                return _selectedPeople;
            }
            set
            {
                _selectedPeople = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPeople"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
