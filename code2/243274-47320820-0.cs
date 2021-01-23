    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void SetIndex(int value)
        {
            lsbMyList.SelectedIndex = value;
        }
    }
    
    public partial class Form1 : Form
    {
        public Form2 frm;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            frm=new Form2();
            frm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frm.SetIndex(Int.Parse(textBox1.Text));
        }
    }
