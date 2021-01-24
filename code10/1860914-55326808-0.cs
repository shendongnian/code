    Timer timer = new Timer{ Interval = 60000, Enabled = true };  //every minute
    timer.Tick += (s, e) =>
    {
        chatverlauf.Items.Clear();
        var StatusList = ... // get list of servers' status
        chatverlauf.SuspendLayout();
        foreach(var s in StatusList)
        {
            chatverlauf.Items.Add(new ListViewItem(new string[]{s.Name, s.Status});
        }
        chatverlauf.RsumeLayout();
    };
