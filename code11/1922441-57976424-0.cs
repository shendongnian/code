    public partial class Form1 : Form
    {
        [DllImport("user32")]
        public static extern bool HideCaret(IntPtr hWnd);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.GotFocus += new EventHandler(textBox1_GotFocus);
        }
        void textBox1_GotFocus(object sender, EventArgs e)
        {
            HideCaret(textBox1.Handle);
        }
    }
