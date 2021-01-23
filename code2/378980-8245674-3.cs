	private void Form1_Load(object sender, EventArgs e)
	{
      CancellationTokenSource cts = new CancellationTokenSource();
      Task worker = new Task(() => DoSomething());
      Task ui_updater = new Task(() => UpdateGui(CancellationToken token));
      worker.Start();
      updater.Start();
	  // Worker task completed, cancel GUI updater.
	  worker.ContinueWith(task => cts.Cancel());
	}
	private void DoSomething()
	{
	 // Do an awful lot of work here.
    }
    private void UpdateGui(CancellationToken token)
    { 
      while (!token.IsCancellationRequested)
     {      
       UpdateLabel();
       Thread.Sleep(500);
     }
    }
    private void UpdateLabel()
    {
      if (this.InvokeRequired)
      {
       this.BeginInvoke(new Action(() => UpdateLabel()), new object[] { });
      }
		else
		{
			label1.Text += ".";
			if (label1.Text.Length >= 5)
				label1.Text = ".";
		}
	}
