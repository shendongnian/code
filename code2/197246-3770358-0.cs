    public class Form1 : Form
    {
        private BackgroundWorker worker;
        private ProgressBar bar;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            bar= new ProgressBar();
            bar.Dock = DockStyle.Top;
            Controls.Add(bar);
    
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress=true;
            worker.RunWorkerCompleted += delegate
                                             {
                                                 Close();
                                             };
            worker.ProgressChanged += delegate(object sender, ProgressChangedEventArgs ev)
                                          {
                                              bar.Value = ev.ProgressPercentage;
                                          };
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }
    
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //do your work here. For the example, just sleep a bit 
            //and report progress
            for (var i = 0; i < 100;i++ )
            {
                Thread.Sleep(50);
                worker.ReportProgress(i);
            }
        }
        
    }
