    // Event handler called when form is shown
    OnShow(Object sender, EventArgs e)
    {
        Button.Enabled = true;
        ....
    }
    // Button click event handler
    ButtonClick(Object sender, EventArgs e)
    {
        // Do all exit processing required, play sound etc
        Button.Enabled = false;
    }
