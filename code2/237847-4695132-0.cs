    public Form1()
    {
        InitializeComponent();
        MyButtonWithState NewButton = new MyButtonWithState();
        NewButton.Text = "My Test Button";
        NewButton.State = 3;
        this.Controls.Add(NewButton);
    }
