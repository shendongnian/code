    class MainViewModel : NotifyPropertyChangedBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _UpdateField(ref _title, value); }
        }
        private bool _isBlack;
        public bool IsBlack
        {
            get { return _isBlack; }
            set { _UpdateField(ref _isBlack, value, _OnIsBlackChanged); }
        }
        private void _OnIsBlackChanged(bool obj)
        {
            Title = IsBlack ? "Black" : "White";
        }
        public MainViewModel()
        {
            IsBlack = true;
            _ToggleIsBlack(); // fire and forget
        }
        private async void _ToggleIsBlack()
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(100));
                IsBlack = !IsBlack;
            }
        }
    }
