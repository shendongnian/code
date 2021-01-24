    private void Pbxkarte_MouseClick(object sender, MouseEventArgs e)
    {
        if (!dots.Contains(e.Location))
        {
            dots.Add(e.Location);
            Pbxkarte.Invalidate();  // show the dots
        }
    }
