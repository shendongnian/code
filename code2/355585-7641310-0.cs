    public partial class Form1 : Form
    {
        ManualResetEvent m_ResetEvent;
        public Form1()
        {
            InitializeComponent();
            m_ResetEvent = new ManualResetEvent(false);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Dialog d = new Dialog { Owner = this, ResetEvent = m_ResetEvent };
            var thread = new Thread(new ParameterizedThreadStart(DoSomething));
            thread.Start(d);
            if (d.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                throw new Exception("Something terrible happened");
            }
        }
        private void DoSomething(object modal)
        {
            Dialog d = (Dialog)modal;     
            
            // Block the thread!
            m_ResetEvent.WaitOne();
            for (int i = 0; i < 1000; i++)
            {
                d.SetWaitLabelText(i.ToString());
                Thread.Sleep(1000);
            }
        }
    }
