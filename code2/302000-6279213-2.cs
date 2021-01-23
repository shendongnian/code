    static Screen ScreenFromPoint1(Point p)
    {
        System.Drawing.Point pt = new System.Drawing.Point((int)p.X, (int)p.Y);
        return Screen.AllScreens
                        .Where(scr => scr.Bounds.Contains(pt))
                        .FirstOrDefault();
    }
    static Screen ScreenFromPoint2(Point p)
    {
        System.Drawing.Point pt = new System.Drawing.Point((int)p.X, (int)p.Y);
        var scr = Screen.FromPoint(pt);
        return scr.Bounds.Contains(pt) ? scr : null;
    }
    
