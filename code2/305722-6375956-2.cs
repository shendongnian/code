    public class MyTimer : System.Timers.Timer
    {
        public MyTimer(double interval)
            : base(interval)
        {
        }
    
        public object Tag { get; set; }
    }
    
    MyTimer timer;
    void test(object sender)
    {
        timer = new MyTimer(1);
        timer.Tag = sender;
        timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
    }
    
    void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        MyTimer timer = (MyTimer)sender;
        object tag = timer.Tag;
        // do whatever you want with tag
    }
