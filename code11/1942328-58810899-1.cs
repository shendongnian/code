    **public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("TestDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void HelloWorld();
        private void button1_Click(object sender, EventArgs e)
        {
            HelloWorld();
        }
    }**
