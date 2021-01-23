    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // make the 'B' key the hot key to trigger the key press event of button1
            button1.Text = "&Button";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("B");
        }
    }
