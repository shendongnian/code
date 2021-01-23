    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
            richTextBox1.KeyPress += new KeyPressEventHandler(richTextBox1_KeyPress);            
        }
        void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);            
        }
    }
