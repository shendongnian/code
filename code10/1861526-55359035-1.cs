	private BackgroundWorker bGWExprtrLod;
	private void Form1_Load(object sender, EventArgs e)
	{
		bGWExprtrLod = new BackgroundWorker();
		bGWExprtrLod.WorkerReportsProgress = true;
		bGWExprtrLod.ProgressChanged += BGWExprtrLod_ProgressChanged;
		bGWExprtrLod.RunWorkerCompleted += BGWExprtrLod_RunWorkerCompleted;
		bGWExprtrLod.DoWork += BGWExprtrLod_DoWork;
	}
	public void SetDaTableAndFileNameFn(System.Data.DataTable DataTable)
	{
		// ... other code ...
		bGWExprtrLod.RunWorkerAsync();
	}
	private void BGWExprtrLod_DoWork(object sender, DoWorkEventArgs e)
	{
		bGWExprtrLod.ReportProgress(0, ">>> Creating And Transferring Data To The File...");
		// ... do some work ...
	}
	private void BGWExprtrLod_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		string msg = e.UserState.ToString();
		richTxtBxExprtr.AppendText(msg);
	}
	private void BGWExprtrLod_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		richTxtBxExprtr.AppendText("Transfer Complete!");
	}
