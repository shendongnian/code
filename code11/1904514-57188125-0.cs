    // Constructor
    public NameForm(Rectangle bounds)
    {
        InitializeComponent();
    
        this.Bounds = bounds;
    }
    // In my case, this is opening the screensaver on all screens
    foreach (Screen screen in Screen.AllScreens)
    {
        NameForm form = new NameForm (screen.Bounds);
        form.Show();
    }
