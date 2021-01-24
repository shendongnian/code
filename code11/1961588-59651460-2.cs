    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Test()
        {
            Action a = () => { textBox1.Text = "A"; };
            textBox1.Invoke(a);
        }
    }
