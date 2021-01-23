    myLabel.Click += new System.EventHandler(MyLabel_Click);
    // ...
    private void MyLabel_Click(object sender, EventArgs e)
    {
       Clipboard.SetText(myLabel.Text);
    }
