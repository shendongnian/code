    public partial class Form1 : Form
    {
        Timer timer;
        string str;
        int char_num;
        
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Tick += timer_Tick;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            SendKeys.Send(str.Substring(char_num++, 1));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            str = "Jonathon";
            char_num = 0;
            timer.Interval = 1000;
            timer.Start();
        }
    }
