    public Form1()
    {
        InitializeComponent();
        elementHost.ChildChanged += ElementHost_ChildChanged;
    }
    private void ElementHost_ChildChanged(object sender, ChildChangedEventArgs e)
    {
        var ctr = (elementHost.Child as UserControl1);
        if (ctr == null)
            return;
        ctr.KeyDown += ctr_KeyDown;
    }
    void ctr_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        /* your custom handling for key-presses */
    }
