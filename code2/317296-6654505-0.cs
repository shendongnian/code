    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Tab) 
        {
            Paste("    ");
            e.SuppressKeyPress = true;
        }
    }
