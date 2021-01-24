    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        public Form1()
        {
            InitializeComponent();
            textBox1.GotFocus += (s1, e1) => { HideCaret(textBox1.Handle); };
        }
    }
