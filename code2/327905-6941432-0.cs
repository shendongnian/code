    public partial class Form1 : Form
    {
        bool is_dsuzey;
        
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (is_dsuzey) textBox1.Text = "1";
        }
        public bool IsDsuzey { get { return is_dsuzey; } set { is_dsuzey = value; } }
    }
