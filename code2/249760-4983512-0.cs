    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }
        // update UI back on main thread
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBox1.Items.AddRange(content.ToArray());
        }
        List<string> content;
        // do work on background thread
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            content = new List<string>();
            // simulate slow update
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(10);
                content.Add(i.ToString());
            }
        }
    }
