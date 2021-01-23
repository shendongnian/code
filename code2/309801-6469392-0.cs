        public partial class Form2 : Form
    {  
        private Thread tstart, trun;
        public Form2()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            tstart = new Thread(InitThread);
            tstart.Start();
        }
        private void InitThread()
        {
            trun = new Thread(new ThreadStart(RunThread));
            trun.Start();
            trun.Join();
            CloseForm(trun.ThreadState);
        }
        private void RunThread()
        {
            for (int i = 0; i < progressBar1.Maximum; i++)
            {
                Thread.Sleep(10);
                progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Increment(1); }));                            
            }
        }
        private void CloseForm(Object state)
        {
            if ((ThreadState)state != ThreadState.Stopped)               
                return;            
            else
            {
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(delegate { this.Close(); }), null);
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tstart.IsAlive)
                tstart.Abort();
            if (trun.IsAlive)
                trun.Abort();
        }
    }
