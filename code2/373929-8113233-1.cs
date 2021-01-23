    public class TimerViewModel : ViewModelBase {
        public TimerViewModel() {
            Timers = new ObservableCollection<TimerModel>();
            AddTimerCommand = new RelayCommand(() => AddTimer());
        }
        public ObservableCollection<TimerModel> Timers {
            get;
            private set;
        }
        public ICommand AddTimerCommand {
            get;
            private set;
        }
        private void AddTimer() {
            Timers.Add(new TimerModel(TimeSpan.FromSeconds((new Random()).Next())));
        }
    }
