    public partial class Form1 : Form
    {
        BackgroundWorker bw = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
    
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.WorkerSupportsCancellation = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnCancel.Enabled = true;
            double[] data = new double[1000000];
            Random r = new Random();
            for (int i = 0; i < data.Length; i++)
                data[i] = r.NextDouble();
            bw.RunWorkerAsync(data);
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStart.Enabled = true;
            btnCancel.Enabled = false;
            if (!e.Cancelled)
            {
                double result = (double)e.Result;
                MessageBox.Show(result.ToString());
            }
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            double[] data = (double[])e.Argument;
            for (int j = 0; j < 200; j++)
            {
                double result = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    if (bw.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    result += data[i];
                }
                e.Result = result;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            bw.CancelAsync();
            btnStart.Enabled = true;
            btnCancel.Enabled = false;
        }
    }
