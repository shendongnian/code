    public MyForm()
    {
        InitializeComponent();
    
        var button = new Button {Enabled = false};
    
        button.Click += ButtonClick;
    
        Controls.Add(button);
    }
    
    void ButtonClick(object sender, EventArgs e)
    {
        MessageBox.Show(@"Clicked!");
    }
