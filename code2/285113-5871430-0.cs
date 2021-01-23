    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == (Keys.Control | Keys.A))
        {
            MessageBox.Show("You pressed Ctrl+A!");
        }
    }
