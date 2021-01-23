    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        // Check to see if the user is allowed to close this form
        if (!allowClose)
        {
           // Prevent this form from being closed
           MessageBox.Show("This form cannot be closed yet!");
           e.Cancel = true;
        }
    }
