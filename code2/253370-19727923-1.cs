    public MainView()
    {
        InitializeComponent();
        // StartPosition was set to FormStartPosition.Manual in the properties window.
        Rectangle screen = Screen.PrimaryScreen.WorkingArea;
        int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
        int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
        this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
        this.Size = new Size(w, h);
    }
