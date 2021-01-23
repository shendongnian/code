    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(ThreadProc);
            thread.Start();
        }
        public void ThreadProc()
        {
            using (Form1 _form = new Form1())
            {
                _form.TopMost = true;
                Application.Run(_form);
            }
        }
    }
