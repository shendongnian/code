    public partial class Form1 : Form
    {
        Timer timer = new Timer { Interval = 10 };
        public Form1()
        {
            InitializeComponent();
            Paint += (s, e) => { };
            timer.Tick += (s, e) => Refresh();
            timer.Start();
        }
    }
