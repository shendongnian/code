    public UserControl1()
    {
         InitializeComponent();
         this.Resize += UserControl1_Resize;
    }
    private void UserControl1_Resize(object sender, EventArgs e)
    {
        if (this.Width > 600)
            ...
    }
