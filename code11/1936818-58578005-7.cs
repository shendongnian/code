    namespace KeyTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
            }
            private void Form1_KeyUp(object sender, KeyEventArgs e)
            {
                CheckKeys(e);
            }
            private void CheckKeys(KeyEventArgs e)
            {
                if (e.KeyCode == Keys.F10)
                {
                    textBox1.Focus();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.F11)
                {
                    textBox2.Focus();
                    e.Handled = true;
                }
            }
        }
    }
