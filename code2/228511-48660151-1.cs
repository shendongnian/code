    private RelayCommand _doubleClickCommand;   
    public ICommand DoubleClickCopyCommand
            {
                get
                {
                    if (_doubleClickCommand == null)
                        _doubleClickCommand = new RelayCommand(OnDoubleClick);
                    return _doubleClickCommand;
                }
            }
    
            private void OnDoubleClick(object obj)
            {
                var clickedViewModel = (DiscoveryUrlViewModel)obj;
            }
