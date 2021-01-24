    private void richTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.OemSemicolon:
                richTextBox.AppendText("Ū");
                e.Handled = true;
                break;
            case Keys.OemBackslash:
                richTextBox.AppendText("X̄");
                e.Handled = true;
                break;
            case Keys.G:
                richTextBox.AppendText("Ʒ");
                e.Handled = true;
                break;
            default:
                // Nothing special here
                break;
        }
    }
