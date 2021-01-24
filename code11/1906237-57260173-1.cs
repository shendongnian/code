    public class ViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public ICommand MouseLeftButtonDownClick { get; }
            public ViewModel()
            {
                MouseLeftButtonDownClick = new RelayCommand(OnMouseLeftButtonClick);
            }
    
            private void OnMouseLeftButtonClick(object obj)
            {
                //Your logic on left button click
            }
    
            public void OnPropertyChanged(string PropName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropName));
            }
        }
