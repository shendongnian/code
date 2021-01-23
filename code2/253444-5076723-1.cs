    public partial class FormMain : Form
    {
        BackgroundWorker _Worker;
        public FormMain()
        {
            InitializeComponent();
            _Worker = new BackgroundWorker();
            _Worker.DoWork += OnWorkerDoWork;
            _Worker.WorkerSupportsCancellation = true;
            this.Shown += OnFormMainShown;
        }
        void OnFormMainShown(object sender, EventArgs e)
        {
            _Worker.RunWorkerAsync();
        }
        void OnWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                if (_Worker.CancellationPending)
                {
                    return;
                }
                Thread.Sleep(100);
                listBox1.Invoke((Action<int>)AddItem, i);
            }
        }
        private void AddItem(int i)
        {
            listBox1.Items.Add(i);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _Worker.CancelAsync();
        }
    }
