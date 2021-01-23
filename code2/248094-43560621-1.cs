    // Instantiate a new ToolTip object. You only need one of these! And if
    // you've added it through the designer (and renamed it there), 
    // you don't even need to do this declaration and creation bit!
    private ToolTip helperTip = new ToolTip();
    public MyForm()
    {
        InitializeComponent();
        // The ToolTip setting. You can do this as many times as you want
        helperTip.SetToolTip(pictureBox1, "Tooltip text");
        // Now you can create other 'definitions', still using the same tooltip! 
        helperTip.SetToolTip(loginTextBox, "Login textbox tooltip");
    }
