    private void txtPlain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        // Check if the KeyCode value has the Keys.Enter flag set
        if ((e.KeyCode & Keys.Enter) == Keys.Enter)
        {
            // Set the IsInputKey property to False
            e.IsInputKey = false;
        }
    }
   
    private void txtPlain_KeyDown(object sender, KeyEventArgs e)
    {
        // Check if the KeyCode value has the Keys.Enter flag set
        if ((e.KeyCode & Keys.Enter) == Keys.Enter)
        {            
            // Show the user a message
            MessageBox.Show("Enter keys are not allowed in this textbox.");
            
            // Prevent the key event from being passed on to the control
            e.Handled = true;
        }
    }
