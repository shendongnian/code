    private void txtcity_KeyPress(object sender, KeyPressEventArgs e)
    {
        // If you want to use the ASCII code, for some reason.
        const int minusAsciiCode = 45;
        // if (e.KeyChar == '-')
        if (e.KeyChar == (char)minusAsciiCode)
        {
            e.Handled = txtcity.Text.Contains("-");
        }
        else
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
    }
