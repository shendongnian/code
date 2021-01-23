            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar))
            {
                
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.IndexOf('.') > -1 &&
                     textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3)
            {
                e.Handled = true;
            }
            }
            
        }
