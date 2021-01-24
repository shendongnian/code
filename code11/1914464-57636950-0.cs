    private void myInput_Leave(object sender, EventArgs e)
    {
        Regex r = new Regex("^[+-]?[0-9]{3}\.[0-9]{3}$");
        Match m = r.Match(InputTextbox.Text);
        if (!m.Success)
        {
             myInput.ForeColor =  Color.Red;  // Text color will go red
             submitBtn.Enabled = false;  // Submit button is disabled now
        }
        else
        {
             myInput.ForeColor =  Color.Black;
             submitBtn.Enabled = true; // Submit button is enabled now
        }
    }
