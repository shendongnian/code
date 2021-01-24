    public class Answer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        private string _Ans;
        public string Ans
        {
            get => _Ans;
            set
            {
                if (_Ans == value)
                    return;
                _Ans = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(FullName));
            }
        }
        public string FullName => $"{Ans}";
        private bool _isSelected;
        public bool IsSelected 
        { 
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                RaisePropertyChanged(nameof(IsSelected));
                TopLevel.SelectedAnswerChanged();
            }
        }
        public List<Datalog> Files { get; set; }
        public MainWindowViewModel TopLevel { get; internal set; }
    }
