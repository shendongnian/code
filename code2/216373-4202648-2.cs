    public partial class Form1 : Form
    {
        public static Form1 Instance { get; private set; }
        public Form1()
        {
            InitializeComponent();
            if (Instance != null)
                throw new Exception("Only one instance of Form1 is allowed");
            Instance = this;
            FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }
        public Button TestButton1 { get { return testButton1; } }
    }
