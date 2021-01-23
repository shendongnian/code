    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            print pr = new print();
            pr.p(this);
        }
    }
    class print 
    {
        public print()
        {
        }
        public void p(Form frm)
        {
            frm.textBox1.Text = "change text";
        }     
    }
