            public DelegateCommand<Window> CloseWindowCommand { get; private set; }
        public MyViewModel()//ctor of your viewmodel
        {
            //do something
            CloseWindowCommand = new DelegateCommand<Window>(CloseWindow);
        }
            public void CloseWindow(Window win) // this method is also in your viewmodel
        {
            //do something
            win?.Close();
        }
