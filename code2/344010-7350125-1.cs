    namespace StringSplitTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                textBox2.Text = "";
                var txt = textBox1.Text;
    
                foreach (string s in txt.ReverseCut(3))
                    textBox2.Text += s + "\r\n";   
            }
        }
    }
    
