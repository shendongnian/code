    private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tmr.Enabled)
            {
                tmr.Enabled = true;
                tmr.Start();
            }
            TimeSinceType = DateTime.Now;
        }
    public DateTime TimeSinceType { get; set; }
    protected void Load()
    {
          tmr = new Timer();
          tmr.Interval = 200;
          tmr.Elapsed += new ElapsedEventHandler(tmr_Elapsed);
    }
    void tmr_Elapsed(object sender, ElapsedEventArgs e)
    {
        if ((DateTime.Now - TimeSinceType).Seconds > .5)
        {
            Dispatcher.BeginInvoke((Action)delegate()
            {
                //LoadData();
                tmr.Stop();
            });
        }
    }
