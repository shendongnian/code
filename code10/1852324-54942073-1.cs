    class ViewModel : INotifyPropertyChanged
    {    
        private readonly Model _model;
        public int X { get; set; }
        public int Y { get; set; }
        private string _result = "";
        public string Result 
        { 
            get
            {
                return _result;
            } 
            private set
            {
                if (_result.Equals(value) == false)
                {
                    _result = value;
                    RaisePropertyChanged();
                }
                
            }
        }
        public ViewModel(Model model) => _model = model;
        public void CalculateResult()
        {
             Result = _model.GetRes().ToString();
        }
        // Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
