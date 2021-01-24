    private void Panel1_MouseLeave(object sender, EventArgs e)
    {
        if (!(sender as Panel).ClientRectangle.Contains(PointToClient(Control.MousePosition)))
        {
            //do animation
        }
    }
