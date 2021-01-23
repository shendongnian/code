    Timer timer = new Timer();
    public void RunMix(object sender, EventArgs e)
    {
      label1.Text = knob1.Angle.ToString();            
    }
    private void Form1_Load(object sender, EventArgs e)
    {
      timer.Interval = 100;
      timer.Tick += new EventHandler(RunMix);
      timer.Start();
    }
