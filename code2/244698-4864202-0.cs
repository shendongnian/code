    int t = 0;
    void timer_Tick2(object sender, EventArgs e)
    {
        t++;
        if (t <= 250)
            pictureBox1.Location = new Point(t*2, y);
        if (t > 250)
        {
            ...
        }
    }
