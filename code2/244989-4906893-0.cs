    public Form1()
    {
        InitializeComponent();
        _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        pictureBox1.Image = _bitmap;
        Timer timer = new Timer();
        timer.Tick += new EventHandler(timer_Tick);
        timer.Interval = 10;
        timer.Start();
    }
    private int x = 0;
    void timer_Tick(object sender, EventArgs e)
    {
        if(++x < _bitmap.Width)
        {
            int y = _bitmap.Height/2 
                    - ((int)(Math.Sin(x * (Math.PI * 2) /  _bitmap.Width) * (_bitmap.Height / 2)));
            //Small rounding error
            if (y > _bitmap.Height - 1)
                y = _bitmap.Height - 1;
            _bitmap.SetPixel(x, y, Color.Black);
        }
        pictureBox1.Image = _bitmap;
    }
