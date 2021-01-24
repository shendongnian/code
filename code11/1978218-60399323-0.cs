    private int x1 = 4;
    System.Windows.Forms.Timer timer;
    private bool once = true;
    private bool up = false;
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        // use e.Graphics
        Graphics g = e.Graphics;
        Pen red = new Pen(Color.Red, 3);
        Rectangle rect = new Rectangle(x1, x1, x1, x1);
        Rectangle circle = new Rectangle(x1 + 10, x1 + 10, x1 + 50, x1 + 50);
        g.DrawRectangle(red, rect);
        g.DrawEllipse(red, circle);
    
        red.Dispose();
        g.Dispose();
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        if (once)
        {
            once = false;
            Init();
        }
        else
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
            // you can exit app...
             Application.Exit();
        }
    }
    
    private void Init()
    {
        if (timer == null)
        {
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += timer_tick;
        }
    
        timer.Start();
    }
    
    private void timer_tick(object sender, EventArgs e)
    {
        if (up)
        {
            x1 += 10;
            if (x1 > 100)
                up = false;
        }
        else
        {
            x1 -= 10;
            if (x1 <= 10)
                up = true;
        }
        this.Invalidate();
    }
