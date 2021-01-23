    public class Generator
    {
        private MyForm myForm;
    
        public Generator()
        {
            InitializeComponent();
        }
    
        public Generator(MyForm frm) : this() // DON'T FORGET THIS()
        {
            myForm = frm;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            myForm.MyDataGridView... // Yay, it works!
        }
    }
    
    public class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent(); // a datagridview is created here, say "datagridview1"
        }
    
        public DataGridView MyDataGridView
        {
            get { return datagridview1; }
        }
    }
