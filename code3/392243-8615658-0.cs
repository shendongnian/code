    void StartProcessOne() {
        Process p = Process.Start("foo", "bar");
        p.Exited += (sender, e) => StartProcessTwo();
        p.Start();
    }
    void StartProcessTwo() {
        Process p = Process.Start("foo2", "bar2");
        p.Exited += (sender, e) => StartProcessThree();
        p.Start();
    }
    ...
