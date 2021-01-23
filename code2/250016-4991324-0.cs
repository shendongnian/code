    private void RedirectMouseMove(object sender, MouseEventArgs e)
    {
        Control control = (Control)sender;
        Point screenPoint = control.PointToScreen(new Point(e.X, e.Y));
        Point formPoint = PointToClient(screenPoint);
        MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks, 
            formPoint.X, formPoint.Y, e.Delta);
        OnMouseMove(args);
    }
