    private void Form1_Load(object sender, EventArgs e)
    {
        Button b = new Button();
        b.Click += new EventHandler(ShowMessage);
        Controls.Add(b);
    }
    
    private void ShowMessage(object sender,EventArgs e)
    {
        MessageBox.Show("Message");
    }
