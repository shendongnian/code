    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private SolidColorBrush defaultBgColor;
        private SolidColorBrush defaultBorderColor;
    
        public ViewModel()
        {
            defaultBgColor = (SolidColorBrush)Application.Current.Resources["TextControlBackground"];
            defaultBorderColor = (SolidColorBrush)Application.Current.Resources["TextControlBorderBrush"];
    
            ValidationColorBackground = (SolidColorBrush)Application.Current.Resources["TextBoxBackgroundThemeBrush"];
            ValidationColorBorder = (SolidColorBrush)Application.Current.Resources["TextBoxBorderThemeBrush"];
        }
        private SolidColorBrush _validationColorBorder;
        public SolidColorBrush ValidationColorBorder
        {
            get { return _validationColorBorder; }
            set
            {
                _validationColorBorder = value;
                RaisePropertyChanged();
            }
        }
    
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private SolidColorBrush _validationColorBackground;
        public SolidColorBrush ValidationColorBackground
        {
            get { return _validationColorBackground; }
            set
            {
                _validationColorBackground = value;
                RaisePropertyChanged();
            }
        }
    
        public ICommand BtnClickCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    ValidationColorBackground = defaultBgColor;
                    ValidationColorBorder = defaultBorderColor;
                });
            }
        }
    
    }
