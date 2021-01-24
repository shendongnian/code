    this.AcceptButton = buttonOK;
    
    ...
    
    private void buttonOK_Click(object sender, EventArgs e)
    {
        string passwordAttempt = textBoxPassword.Text;
        if (passwordAttempt.CompareTo("pass") == 0)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
