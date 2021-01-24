    private void ntfy2_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
                    var relativeClickedPosition = e.Location;
            var screenClickedPosition = (sender as Control).PointToScreen(relativeClickedPosition);
            contextMenuStrip1.Show(screenClickedPosition);
        }
    }
