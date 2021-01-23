    private void button1_Click(object sender, EventArgs e)
    {
        if (_focusedControl != null)
        {
            //Change the color of the previously-focused textbox
            _focusedControl.BackColor = Color.Red;
        }
    }
