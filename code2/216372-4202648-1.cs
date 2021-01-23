    public class Form1 : Form
    {
        public static Form1 Instance { get; private set; }
        public Form1()
        {
            InitializeComponents();
            Instance = this;
        }
        public Button TestButton1 { get { return testButton1; } }
    }
