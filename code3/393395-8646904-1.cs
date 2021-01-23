    public void Button1_Click(Object sender, EventArgs e)
    {
        timer1.Interval = 1000;
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        DrawMap ortamcizdir = new DrawMap(p_box_map, bmp, ZoomControl, panel1);
        DrawCell hucrecizdir = new DrawCell (p_box_map, bmp, a, ZoomControl, ZoomKontrolBolen);
    }
