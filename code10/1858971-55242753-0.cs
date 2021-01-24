    public DelegateCommand UpdateCommand { get; private set; }
    public ViewModel()
    {
        UpdateCommand = new DelegateCommand(Update);
        ApplicationCommands.SaveCommand.RegisterCommand(UpdateCommand);
    }
