    private View()
    {
        InitializeComponent();
        ViewModel vm = new ViewModel();
        this.DataContext = vm;
        if ( vm.CloseAction == null )
            vm.CloseAction = new Action( () => this.Close() );
    }
