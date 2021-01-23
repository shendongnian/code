    private void MyControl_MouseMove(object sender, MouseEventArgs e)
    {
        if(Parent == null)
            return;
        // add this control's offsets first so the coordinates fit to the parent control
        e.X += this.Top;
        e.Y += this.Left;
        if(parent.MouseMove != null)
            parent.MouseMove(sender, e);
    }
