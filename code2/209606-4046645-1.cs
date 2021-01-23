    public partial class Form1 : Form
    {
        MyClass myClass = new MyClass("one", "two");
        BindingSource bindingSource = new BindingSource();
    
        public Form1()
        {
            InitializeComponent();
    
            bindingSource.DataSource = myClass;
    
            textBox1.DataBindings.Add("Text", bindingSource, "Text1", true, DataSourceUpdateMode.Never);
            textBox2.DataBindings.Add("Text", bindingSource, "Text2", true, DataSourceUpdateMode.Never);                
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource.RaiseListChangedEvents = false;
            myClass.Text1 = textBox1.Text;
            myClass.Text2 = textBox2.Text;
            bindingSource.RaiseListChangedEvents = true;
        }
    }
