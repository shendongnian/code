    public Form1()
    {
        _bgw.DoWork += BgwDoWork;
        _bgw.RunWorkerCompleted += BgwRunWorkerCompleted;
        _bgw.RunWorkerAsync();
        _msg.ShowDialog();
        _msg2.ShowDialog();   // here
    }
    
    private void BgwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        _msg.Close();
        //_msg2.ShowDialog();  // not here
    }
