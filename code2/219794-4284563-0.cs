    private void someTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                someTextBox_Validating(sender, new CancelEventArgs());
            }
        }
