    private void FixAddressBtn_Click(object sender, EventArgs e)
    {
        const int maxLength = 25;
        if (LongAddressText.Text.Length <= maxLength)
        {
            Address1Text.Text = LongAddressText.Text;
            Address2Text.Text = string.Empty;
            return;
        }
        for (int i = maxLength - 1; i >= 0; --i)
        {
            if (LongAddressText.Text[i] == ' ')
            {
                Address1Text.Text = LongAddressText.Text.Substring(0, i);
                Address2Text.Text = LongAddressText.Text.Substring(i+1);
                return;
            }
        }
        //no obvious way to split it, so just brute force:
        Address1Text.Text = LongAddressText.Text.Substring(0, 24);
        Address2Text.Text = LongAddressText.Text.Substring(24);
    }
