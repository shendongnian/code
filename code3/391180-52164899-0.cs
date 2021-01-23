     private void TxtBox1_textChanged(object sender, EventArgs e)
        {
            if (!IsDigitsOnly(contactText.Text))
            {
                contactText.Text = string.Empty;
            }
        }
    private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
