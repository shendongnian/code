    private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
    {
        e.Control.LostFocus += new EventHandler(Control_LostFocus);
    }
    void Control_LostFocus(object sender, EventArgs e)
    {
        Control c = (Control)sender;
        //some code you want write for controls that lost focus
    }
