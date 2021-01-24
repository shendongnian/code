        public class MainWindowVM : INotifyPropertyChanged
    {
        private readonly List<UserControl1VM> childVms;
        public UserControl1VM UserControlVM1 { get; set; }
        public UserControl1VM UserControlVM2 { get; set; }
        public UserControl1VM UserControlVM3 { get; set; }
        public MainWindowVM()
        {
            childVms = new List<UserControl1VM>()
            {
                new UserControl1VM(),
                new UserControl1VM(),
                new UserControl1VM(),
            };
            UserControlVM1 = childVms[0];
            UserControlVM2 = childVms[1];
            UserControlVM3 = childVms[2];
            AddSum = new RelayCommand(DoAddSum);
        }
        private int _Sum;
        public int Sum
        {
            get { return _Sum; }
            set
            {
                _Sum = value;
                OnPropertyChanged("Sum");
            }
        }
        public RelayCommand AddSum { get; set; }
        private void DoAddSum(object obj)
        {
            childVms.ForEach(vm => Sum += vm.txt);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
