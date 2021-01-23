    public class OnOffSwitchClass : ViewModelBase // ignore that it's derived from ViewModelBase!
    {
        private const Int32 TIMER_INTERVAL = 5000;  // 5 seconds
        private Timer _timer;
        // Upon creation create a timer that changes the value every 5 seconds
        public OnOffSwitchClass()
        {
            _timer = new System.Threading.Timer(TimerCB, this, TIMER_INTERVAL, TIMER_INTERVAL);
        }
        private static void TimerCB(object state)
        {
            // Alternate between on and off
            ((OnOffSwitchClass)state).PowerState = !((OnOffSwitchClass)state).PowerState;
        }
        public const string PowerStatePropertyName = "PowerState";
        private bool _myProperty = false;
        public bool PowerState
        {
            get
            {
                return _myProperty;
            }
            set
            {
                if (_myProperty == value)
                {
                    return;
                }
                var oldValue = _myProperty;
                _myProperty = value;
                // Update bindings and broadcast change using GalaSoft.MvvmLight.Messenging
                GalaSoft.MvvmLight.Threading.DispatcherHelper.CheckBeginInvokeOnUI(() =>
                    RaisePropertyChanged(PowerStatePropertyName, oldValue, value, true));
            }
        }
    }
