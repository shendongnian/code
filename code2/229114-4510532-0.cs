    pb.Visible = true;
    var timer = new Timer();
    timer.Tick += () => { pb.Visible = false; timer.Stop(); };
    timer.Interval = 3000;
    timer.Start();
