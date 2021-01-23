     public delegate void ClickMe (string message);
    public partial class CustomControl : UserControl
    {
        public event ClickMe CustomControlClickMe;
        public CustomControl()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CustomControlClickMe != null)
                CustomControlClickMe("Hello");
        }
  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            customControl1.CustomControlClickMe += new ClickMe(button2_Click);
        }
        void button2_Click(string message)
        {
            MessageBox.Show(message);
        }
