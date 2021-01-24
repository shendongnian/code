    public partial class Form1 : Form
    {
        public Form1(Func<double, double>CalculateValue)
        {
            InitializeComponent();
            button1.Click += (sender, eventArgs) => textBox1.Text = CalculateValue(.0025).ToString();
        }
    }
