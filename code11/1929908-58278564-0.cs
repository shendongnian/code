     private void All_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                var senderText = (sender as TextBox);
                // check if it's in the beginning of text not accept and check if there is already exist a '.'
                if (senderText != null && (senderText.TextLength == 0 || senderText.SelectionStart == 0 || (senderText.Text.IndexOf('.') > -1)))
                {
                    e.Handled = true;
                }
            }
        }
