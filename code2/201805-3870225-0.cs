    private Control activeControl;
    private Point previousLocation;
    private void button1_Click(object sender, EventArgs e)
    {
        var textbox = new TextBox();
        textbox.Location = new Point(50, 50);
        textbox.MouseDown += new MouseEventHandler(textbox_MouseDown);
        textbox.MouseMove += new MouseEventHandler(textbox_MouseMove);
        textbox.MouseUp += new MouseEventHandler(textbox_MouseUp);
        this.Controls.Add(textbox);
    }
    void textbox_MouseDown(object sender, MouseEventArgs e)
    {
        activeControl = sender as Control;
        previousLocation = e.Location;
        Cursor = Cursors.Hand;
    }
    void textbox_MouseMove(object sender, MouseEventArgs e)
    {
        if (activeControl == null || activeControl != sender)
            return;
        var location = activeControl.Location;
        location.Offset(e.Location.X - previousLocation.X, e.Location.Y - previousLocation.Y);
        activeControl.Location = location;
    }
    void textbox_MouseUp(object sender, MouseEventArgs e)
    {
        activeControl = null;
        Cursor = Cursors.Default;
    }
