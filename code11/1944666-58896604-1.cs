    private int _counter; // instance field, field to remember your count
    private void DrawerTimer_Tick(object sender, EventArgs e)
    {
        newsLabel.Top -= 10;
        counter++; // increment it every tick
        if (counter == 2)
            drawerTimer.Stop();
    }
    private void News_Click(object sender, EventArgs e)
    {
        _counter = 0; // set to zero when start
        drawerTimer.Start();
    }
