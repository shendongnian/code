    if (m.Msg == WM_CTLCOLORSTATIC)
    {
        // set your other colors for disabled controls
        using (var g = Graphics.FromHwnd(Handle)
        {
            using (var p = new Pen(Color.FromArgb(93, 100, 103))
            {
                // its a fat border so we need to draw 3 rectangles to cover it
                g.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
                g.DrawRectangle(p, 1, 1, Width - 3, Height - 3);
                g.DrawRectangle(p, 2, 2, Width - 5, Height - 5);
            }
        }
    ]
