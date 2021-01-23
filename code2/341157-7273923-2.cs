    namespace WindowsFormsApplication1
    {
    public partial class Form2 : Form
    {
        Form1 frm1;
        public Form2(Form1 parent)
        {
            InitializeComponent();
            frm1 = parent;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            frm1.Visible = false;
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            frm1.Visible = true;
        }
    }
    }
