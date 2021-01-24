    public partial class Form1 : Form
    {
        private Timer timer3;
        private int counter;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            counter = 0;
            timer3 = new Timer();
            timer3.Interval = 3000;
            timer3.Tick += Timer3_Tick;
            timer3.Start();
        }
        private void Timer3_Tick(object sender, EventArgs e)
        {
            counter++;
            label1.Text = counter.ToString();
        }
    }
