    public partial class Form1 : Form
    {
    
        public MyClass myClass { get; set; }
    
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            myClass = new MyClass();
            myClass.AddStuff("uno", "UNO");
    
            Binding b = new Binding("Text", myClass, "Dic");
            b.Parse += new ConvertEventHandler(b_Parse);
            b.Format += new ConvertEventHandler(b_Format);
            textBox1.DataBindings.Add(b);
        }
    
        void b_Format(object sender, ConvertEventArgs e)
        {
            e.Value = (e.Value as Dictionary<string, string>)["uno"].ToString();
            textBox1.Text = e.Value.ToString();
        }
    
        void b_Parse(object sender, ConvertEventArgs e)
        {
            MessageBox.Show("This is executed when you lost focus\n\nI'm parsing your entered text: " + e.Value);
        }
    
      
    }
