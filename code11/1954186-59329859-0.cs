    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }
        public string Value
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }
    }
