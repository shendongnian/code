    public string PassWord
    {
    
        get { return _passWord; }
        set
        {
            if(value != null && IsPasswordContentAcceptable(value))
            {
                _passWord = value;
                OnPropertyChanged();
            }
            else
            {
                InputInjector inputInjector = InputInjector.TryCreate();
                var info = new InjectedInputKeyboardInfo();
                info.VirtualKey = (ushort)(VirtualKey.Back);
                inputInjector.InjectKeyboardInput(new[] { info });               
            }
           
        }
    }
