    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        // look for the expected key
        if (keyData == Keys.A)
        {
            // take some action
            MessageBox.Show("The A key was pressed");
            // eat the message to prevent it from being passed on
            return true;
            // (alternatively, return FALSE to allow the key event to be passed on)
        }
 
        // call the base class to handle other key events
        return base.ProcessCmdKey(ref msg, keyData);
    }
