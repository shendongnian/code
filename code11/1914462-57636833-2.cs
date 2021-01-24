    private void InputTextbox_Leave(object sender, EventArgs e)
    {
        Regex r = new Regex("^[+-]?[0-9]{3}\.[0-9]{3}$");
        Match m = r.Match(InputTextbox.Text);
        if (m.Success)
        {
            // Code
        }
    }
