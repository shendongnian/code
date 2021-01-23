    private ICommand _openHyperlinkCommand;
    public ICommand OpenHyperlinkCommand {
        get
        {
            if (_openHyperlinkCommand == null) 
                _openHyperlinkCommand = new RelayCommand<object>(p => ExecuteHyperlink());
            return _openHyperlinkCommand;
        }
    }
    private void ExecuteHyperlink() {
        //do stuff here
    }
