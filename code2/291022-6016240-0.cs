    private void SetPenThickness(int thickness)
    {
        CurrentPanel.PenThickness = thickness;
    }
    toolStripMenuItem1.Click += (s,e) => SetPenThickness(1);
    toolStripMenuItem2.Click += (s,e) => SetPenThickness(2);
    toolStripMenuItem3.Click += (s,e) => SetPenThickness(3);
    toolStripMenuItem4.Click += (s,e) => SetPenThickness(4);
    // ...
