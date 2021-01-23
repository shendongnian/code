    // g is your Graphics object
    using (var path = new GraphicsPath())
    {
        path.AddString(.... );
        g.Clip.Exclude(path);
    }
    // Do your other painting here
