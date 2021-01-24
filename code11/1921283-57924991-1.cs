    private void richTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.OemSemicolon:
                richTextBox.AppendText("Ū");
                e.SuppressKeyPress = true;
                break;
            case Keys.OemBackslash:
                richTextBox.AppendText("X̄");
                e.SuppressKeyPress = true;
                break;
            case Keys.G:
                richTextBox.AppendText("Ʒ");
                e.SuppressKeyPress = true;
                break;
            default:
                // Nothing special here
                break;
        }
    }
