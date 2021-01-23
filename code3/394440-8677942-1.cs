    namespace test.ViewModel
    {
        public class StartViewModel : ViewModelBase
        {
            private UCStastistikViewModel _myControlViewModel;
    		
            public StartViewModel()
            {
                _myControlViewModel = new UCStastistikViewModel();
            }
    
            public UCStastistikViewModel MyControlViewModel
            {
                get { return _myControlViewModel; }
                set
                {
                    if (value == _myControlViewModel)
                        return;
    
                    _myControlViewModel = value;
                    OnPropertyChanged("MyControlViewModel");
                }
            }
        }
    }
