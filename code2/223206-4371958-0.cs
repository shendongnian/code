    public void MyFunction()
    {
        firstForm.ShowDialog();
        secondForm.Show();
    }
    
    public void firstForm_Load(object sender, EventArgs e)
    {
        Timer timer = new System.Windows.Forms.Timer() { Interval = 2000 };
        timer.Tick += delegate { timer.Stop(); Close(); };
        timer.Start();
    }
