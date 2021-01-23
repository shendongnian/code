    public MySlider() {
        this.InitializeComponent();
        ScrollLeft = true;
        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMilliseconds(0.01);
        timer.Tick += new EventHandler(timer_Tick);
    }
    void timer_Tick(object sender, EventArgs e) {
        if (ScrollLeft) MyScrollViewer.ScrollToHorizontalOffset(MyScrollViewer.HorizontalOffset - 0.1);
        else MyScrollViewer.ScrollToHorizontalOffset(MyScrollViewer.HorizontalOffset + 0.1);
    }
    private void Left_MouseEnter(object sender, MouseEventArgs e) {
        ScrollLeft = true;
        timer.Start();
    }
    private void Right_MouseEnter(object sender, MouseEventArgs e) {
        ScrollLeft = false;
        timer.Start();
    }
    private void Left_MouseLeave(object sender, MouseEventArgs e) {
        timer.Stop();
        ScrollLeft = false;
    }
    private void Right_MouseLeave(object sender, MouseEventArgs e) {
        timer.Stop();
    }
