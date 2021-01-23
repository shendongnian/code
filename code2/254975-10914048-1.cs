    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
        }
        if (e.Control == true)
        {
            switch (e.KeyCode)
            {
                case Keys.C:
                case Keys.P:
                case Keys.X:
                    e.Handled = true;
                    textBox1.SelectionLength = 0;
                    break;
            }
        }
    }
    private void textBox1_Enter(object sender, EventArgs e)
    {
        System.Windows.Forms.Clipboard.Clear();
    }
