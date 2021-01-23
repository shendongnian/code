    public Form1()
    {      
        MaximizeBox = false;
        MinimizeBox = false;
        FormClosing += OnFormClosing;
    }
    public void OnFormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
        }
    }
