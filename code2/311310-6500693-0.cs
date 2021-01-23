    private void Form_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.NumPad0)
        {
            Button0.PerformClick()
            e.Handled = true;
        }
        else if (e.KeyCode == Keys.NumPad1)
        {...}
        ...
    }
