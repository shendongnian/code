     public ICommand PanRightCmd 
        {
            get { return (ICommand)GetValue(SearchBarEnterCmdProperty); }
            set { SetValue(SearchBarEnterCmdProperty, value); }
        }
...
                PanRightCmd= new RelayCommand(o => PanRightCmdExecute());
