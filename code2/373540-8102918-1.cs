    public partial class Form1 : Form
    {
        private readonly Timer _timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            _timer.Interval = 500;
            _timer.Tick += (o, ea) => UpdateWithRandomSizes();
            _timer.Start();
        }
        private void UpdateWithRandomSizes()
        {
            var rand = new Random();
            label1.Text = new string('A', rand.Next(10));
            label2.Text = new string('B', rand.Next(10));
            label3.Text = new string('C', rand.Next(10));
            label4.Text = new string('D', rand.Next(10));
            tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.AutoSize;
            tableLayoutPanel2.ColumnStyles[0].SizeType = SizeType.AutoSize;
            var width1 = tableLayoutPanel1.GetColumnWidths()[0];
            var width2 = tableLayoutPanel2.GetColumnWidths()[0];
            var max = Math.Max(width1, width2);
            tableLayoutPanel1.ColumnStyles[0].Width = max;
            tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Absolute;
            tableLayoutPanel2.ColumnStyles[0].Width = max;
            tableLayoutPanel2.ColumnStyles[0].SizeType = SizeType.Absolute;
        }
    }
