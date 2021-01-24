    private void Pbxkarte_MouseMove(object sender, MouseEventArgs e)
    {
        bool hit = false;
        foreach (var dot in dots)
        {
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(fromPoint(dot, dotSize));
                if (gp.IsVisible(e.Location))
                {
                    hit = true; break;
                }
            }
        }
        Cursor = hit ? Cursors.Hand : Cursors.Default;
    }
