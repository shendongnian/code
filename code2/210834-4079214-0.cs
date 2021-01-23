    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public delegate void MyHandler1(object sender, EventArgs e);
    
            public Form1()
            {
                InitializeComponent();
    
                List<string> names = new List<string>();
                names.Add("S");
                names.Add("I");
                names.Add("G");
    
                listBox1.DataSource = names;
                listBox1.Click += clicked;
    
    
            }
    
            public void clicked(object sender, EventArgs e)
            {
                label1.ResetText();
                label1.Text = listBox1.SelectedItem.ToString();
            }
        }
    }
