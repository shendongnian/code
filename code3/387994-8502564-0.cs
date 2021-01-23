    public PingIPRange()
    {
        InitializeComponent();
    
        txtF1.TextChanged += new EventHandler(PasteNumbers);
    }
    
    private void PasteNumbers(object sender, EventArgs e)
    {
        if (txtF1.TextLength > 9) { txtF4.Text = txtF1.Text.Substring(9, 3); }
        if (txtF1.TextLength > 6) { txtF3.Text = txtF1.Text.Substring(6, 3); }
        if (txtF1.TextLength > 3)
        {
           txtF2.Text = txtF1.Text.Substring(3, 3);
           txtF1.Text = txtF1.Text.Substring(0, 3);
        }
    }
