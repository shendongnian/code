    public CustomPopupViewModel(IEventAggregator eventAggregator)
    {
        eventAggregator.GetEvent<CloseDialogEvent>().Subscribe( id => { if (id == _id) CloseMe(); } );
    }
    public void OnDialogOpened(IDialogParameters parameters)
    {
        _id = parameters.GetValue<string>("id");
    }
    _dialogService.Show("CustomPopupView", new DialogParameters("id=12345"), result => { });
    _eventAggregator.GetEvent<CloseDialogEvent>().Publish("12345");
