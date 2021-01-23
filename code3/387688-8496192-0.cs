    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //add event keydown
            textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
        }
        void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode )
            {
               
                case Keys.Enter:
                    //YOur updatecode here:
                    MessageBox.Show("You press enter");
                    break;
               
                default:
                    break;
            }
        }
    }
