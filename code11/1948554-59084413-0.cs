    public class MainViewModel : ViewModelBase
    {
        private bool _progressRingActive;
        public bool ProgressRingActive
        {
            get => _progressRingActive;
            set
            {
                _progressRingActive = value;
                RaisePropertyChanged();
            }
        }
    
        ......
    }
