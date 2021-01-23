    public partial class Form1 : Form
    {            
        // ...
     
        private void Form1_Load(object sender, EventArgs e)
        {                                              
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += 
              new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.RunWorkerAsync();
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Your work is completed, not needed but can be handy
            // e.g. to report in some way that the work is done:
            progressBar1.Value = progressBar1.Maximum;
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_elapsed);
            timer.Start();
            // Simulates your long running task (FunctionToBeExecuted)
            // Your main UI thread is free!
            Thread.Sleep(10000);
            
            timer.Stop();
        }
        // ...
    }
