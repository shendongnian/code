    // Code from Form 1
    public partial class Form1 : Form
    {
        private TheClass thClass;
        public Form1()
        {
            InitializeComponent();
        }
        public void foo()
        { 
            thClass = new TheClass(...);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 objForm2 = new Form2(thClass);
            objForm2.Show();
        }
    }
    
    // Code From Form 2
    public partial class Form2 : Form
    {
        private TheClass thClass;
        public Form2(TheClass thCls)
        {
            thClass = thCls;
            InitializeComponent();
        }
    
        private void baa(object sender, EventArgs e)
        {
            thClass.MethodName( .. );
        }
    }
