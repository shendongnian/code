    class MainViewModel
    {
        public SecondViewModel SecondViewModel { get; }
        public RelayCommand ShowSecondViewCommand { get; set; }
        public RelayCommand GrabDataFromSecondViewModelCommand { get; set; }
        public MainViewModel()
        {
            this.SecondViewModel = new SecondViewModel();
            ShowSecondViewCommand = new RelayCommand(o =>
            {
                var SecondView = new SecondView() { DataContext = this.SecondViewModel };
                SecondView.ShowDialog();
            }, o => true);
            GrabDataFromSecondViewModelCommand = new RelayCommand(o =>
            {
                // Directly access the view model
                string valueFromAssociatedViewModel = this.SecondViewModel.Name;
            }, o => true);
        }
    }
