    public partial class Form1 : Form
    {
        public static Form1 Singleton { get; private set; }
        public Form1()
        {
            Form1.Singleton = this;
            InitializeComponent();
        }
    }
