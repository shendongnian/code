    class A
    {
        public int I
        {
            get;
            set;
        }
        public override string ToString()
        {
            return "I=" + I.ToString();
        }
    }
 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
 
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = new[]
            {
                new A { I = 1},
                new A { I = 2},
            };
        }
    }
