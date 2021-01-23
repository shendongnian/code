    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var tb = (TextBox)sender;
        Control ctl = tb.Parent;
        while (ctl != null && !(ctl is TabPage))
        {
            ctl = ctl.Parent;
        }
        if (parent != null)
        {
            var tp = (TabPage)parent;
            // Change the TabPage name here
        }
    }
