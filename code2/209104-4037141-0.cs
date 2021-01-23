    public partial class Form1 : Form
    {
        // ...
        public System.Timers.Timer timer = new System.Timers.Timer(1000); 
        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_elapsed);
            timer.Start();
            // Simulates your long running task (FunctionToBeExecuted)
            // NOTE: This freezes the main UI thread for 10 seconds, 
            //       so nothing will be drawn *at all*            
            Thread.Sleep(10000); 
            timer.Stop(); 
        }
        void timer_elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (InvokeRequired) 
                this.BeginInvoke(new Action(progressBar1.PerformStep));            
            else
                progressBar1.PerformStep(); 
        }        
    }
