    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 f2 = new Form2(this);
        private void Form1_Load(object sender, EventArgs e)
        {
            f2.Show();
        }
        public void data(string name,bool re)
        {
            label1.Text = name;
            if (re == true)
                label1.BackColor = Color.Lime;
            else
                label1.BackColor = Color.Red;
        }
    }
