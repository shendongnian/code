    public static void punchDown(Control ctl)
    {
        Control p = ctl.Parent;
        if (p == null) return;  // this will not work without a parent!
        Region r = new Region();
        r.Union(ctl.Bounds);
        foreach (Control c in ctl.Controls)
        {
            r.Exclude(c.Bounds);
            Point pc = c.PointToScreen(Point.Empty);
            c.Location = ctl.PointToClient(pc);
            c.Parent = p;
        }
        ctl.Region = r;
    }
