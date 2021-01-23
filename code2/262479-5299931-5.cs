    public Form1()
    {
        InitializeComponent();
    
        ElementHost elhost = new ElementHost();
        elhost.Size = new Size(174, 24);
        elhost.Location = new Point(93,60);
        MyWPFControl wpfctl = new MyWPFControl();
        elhost.Child = wpfctl;
        this.Controls.Add(elhost);
        elhost.BringToFront();
    
        wpfctl.SelectionChanged += myWPFControls_SelectionChanged;
    }
    
    private void myWPFControls_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        status_change(e.SelectedIndex);
    }
