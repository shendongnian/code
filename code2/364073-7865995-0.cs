    public Form1()
    {
        InitializeComponent();
        TB_userName.DataBindings.Add("Text", userToBind, "name");
    }
