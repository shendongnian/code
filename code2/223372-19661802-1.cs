    public ClientConfigView()
    {
        InitializeComponent();
        Mediator.ListenOn(Mediator.Token.ConfigWindowShouldClose, callback => this.Close() );
    }
