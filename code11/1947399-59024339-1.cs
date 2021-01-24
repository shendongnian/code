    public delegate void AddDelegate(String name);
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public event AddDelegate AddEvent;
        private void btOK_Click(object sender, EventArgs e)
        {
            AddEvent(textBox1.Text);
            this.Close();
        }
    }
 
