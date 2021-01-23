    namespace WindowsFormsApplication1
    {
    public class SomewhereElse
    {
        public void SomeFunction()
        {
             Form1 form1= new Form1();
             Form2 form2= new Form2();
             
             form1.frm2 = form2;
             form2.frm1 = form1;
        }
    }
    public partial class Form2 : Form
    {
        public Form1 frm1 {get; set;}
        public Form2(Form1 parent)
        {
            InitializeComponent();
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
    public partial class Form1 : Form
    {
        public Form2 frm2 {get; set;}
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            frm2.Visible = false;
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            frm2.Visible = true;
        }
    }
    }
