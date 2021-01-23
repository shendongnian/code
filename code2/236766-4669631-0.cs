    public RelayCommand LogonCommand { get; private set; }
    
    LogonCommand = new RelayCommand(
                        Logon,
                        CanLogon
                    );
    private Boolean CanLogon(){
        return !String.IsNullOrWhiteSpance(SomeProperty);
    }
