    partial class MyForm {   
        Button btnStartStop;
        ProgressBar progressBar;
        // Do this somewhere:
        // btnStartStop.Click += BtnStartStop_Click;
        int threads = 0;              // 0 means "The number of CPU cores"
        DataTable Prof, Prop, Rango;  // You have to provide these values
        // The final results will be stored here:
        DataTable Result;
        CancellationTokenSource cancellation;
        ParallelCalculation calculation;
        System.Windows.Forms.Timer progressTimer;
        void BtnStartStop_Click(object sender, EventArgs e)
        {
            if (calculation != null)
                cancellation.Cancel();
            else
                StartCalculation();
        }
        void StartCalculation()
        {
            cancellation = new CancellationTokenSource();
            calculation = new ParallelCalculation { Prof = this.Prof, Prop = this.Prop, Rango = this.Rango };
            calculation.Run(Finished, cancellation.Token, threads);
            progressBar.Value = 0;
            progressTimer = new System.Windows.Forms.Timer(components) { Interval = 100 };
            progressTimer.Tick += ProgressTimer_Tick;
            progressTimer.Start();
            UpdateUI();
        }
        void Finished(DataTable table, Exception e)
        {
            BeginInvoke((Action)delegate
            {
                Result = table;
                progressBar.Value = (int)(calculation.Progress() * 100);
                progressTimer.Stop();
                progressTimer.Tick -= ProgressTimer_Tick;
                calculation = null;
                UpdateUI();
            });
        }
        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (calculation != null)
                progressBar.Value = (int)(calculation.Progress() * 100);
        }
        void UpdateUI()
        {
            if (calculation == null)
            {
                btnStartStop.Text = "Start";
            }
            else
            {
                btnStartStop.Text = "Stop";
            }
        }
    }
