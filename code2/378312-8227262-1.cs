    private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
    {
        if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
        {
            treeView1.Focus();
            SendKeys.Send(e.KeyCode == Keys.Up ? "{UP}" : "{DOWN}");
        }
    }
