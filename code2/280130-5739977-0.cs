    Timer t = new Timer();
    
    t.Interval = 2000;
    
    timer1.Enabled = true;
    
    timer1.Tick += new System.EventHandler(OnTimerEvent);
    
    private void OnTimerEvent(object sender, EventArgs e)
    
    {
    
        listBox1.Items.Add(DateTime.Now.ToLongTimeString() + "," + DateTime.Now.ToLongDateString());
    
    }
