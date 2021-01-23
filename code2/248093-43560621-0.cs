    private ToolTip helperTip;
    public MyForm()
    {
        InitializeComponent();
        // The ToolTip inicialization. Do this only once.
        helperTip = new ToolTip(pictureBox1, "Tooltip text");
        // Now you can create other 'definitions', still using the same tooltip! 
        helperTip.SetToolTip(loginTextBox, "Login textbox tooltip");
    }
