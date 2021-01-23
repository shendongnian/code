    private void pb_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) 
    {
        Point mouseDownLocation = (Control)sender.PointToClient(new Point(e.X, e.Y));
        //here goes your if condition ...
    }
