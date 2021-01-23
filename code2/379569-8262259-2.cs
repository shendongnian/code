    private System.Windows.Forms.Timer _timer; 
    public ClassConstructor () {
        _timer = new System.Windows.Forms.Timer();
        _timer.Interval = 100;  // Set the "sensitivity"
        _timer.Elapsed += new ElapsedEventHandler(OnTimer);
    }
    private void btnPlus_MouseDown(object sender, MouseEventArgs e)
    {
        timer.Start();
    }
    private void btnPlus_MouseDown(object sender, MouseEventArgs e)
    {
        timer.Stop();
    }
    private void OnTimer(object sender, ElapsedEventArgs e) {
        rect.Width = rect.Width + 1;
        rect.Height = (int)(((rect.Width) / 4) * 3);
        label1.Text = rect.Width.ToString();
        label2.Text = rect.Height.ToString();
        pictureBox1.Invalidate();
    }
