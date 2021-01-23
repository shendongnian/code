    public partial class Form2 : Form
    {
        string sname;
        string sID;
    
        public Form2(string name, string id, Form a)
        {
            sname = name;
            sID = id;
            
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = sname + " ID" + sID;
        }
    }
