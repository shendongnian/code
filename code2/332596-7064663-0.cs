    private void GestureListener_Flick(object sender, FlickGestureEventArgs e)
    {
        if (e.Direction == System.Windows.Controls.Orientation.Horizontal)
        {
            if (e.HorizontalVelocity < 0)
            {
                // flick right
            }
            else
            {
                // flick left
            }
        }
        else
        {
            if (e.VerticalVelocity < 0)
            {
                // flick up
            }
            else
            {
                // flick down
            }
        }
    }
