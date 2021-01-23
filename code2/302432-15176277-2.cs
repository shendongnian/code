    void RTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyData == Keys.Enter)
        {
            //do ...
            bool temp = Multiline;
            Multiline = true;
            e.Handled = true;
            Multiline = temp;
        }
    }
