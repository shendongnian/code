    // this probably should be in your form initialization
    this.MouseClick += new MouseEventHandler(MouseClickEvent);
    void MouseClickEvent(object sender, MouseEventArgs e)
    {
        // do whatever you need with e.Location
    }
