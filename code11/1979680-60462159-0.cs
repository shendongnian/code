    public class MainVM
    {
        private readonly ISplashScreenService _waitIndicatorService;
        private bool _isBusy;
        public virtual bool IsBusy 
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                OnIsBusyChanged();
            }
        }
        public MainVM()
        {
            _waitIndicatorService = 
                ServiceContainer.Default.GetService<ISplashScreenService>("WaitIndicatorService");
        }
        protected void OnIsBusyChanged()
        {
            _waitIndicatorService.SetSplashScreenState("Doing some work...");
            if (IsBusy)
                _waitIndicatorService.ShowSplashScreen();
            else
                _waitIndicatorService.HideSplashScreen();
        }
    }
