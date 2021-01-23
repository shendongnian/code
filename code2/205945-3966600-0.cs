    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += (s, evt) =>
            {
                throw new InvalidOperationException("oops");
            };
            worker.RunWorkerCompleted += (s, evt) =>
            {
                if (evt.Error != null)
                {
                    MessageBox.Show(evt.Error.Message);
                }
            };
            worker.RunWorkerAsync();
        }
    }
