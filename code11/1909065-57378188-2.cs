    public class TaskDialog : Form
    {
        public string ScanNumber { get; set; }
        public TaskDialog()
        {
            InitializeComponent();
        }
        public TaskDialog(string scanNumber)
        {
            this.ScanNumber = scanNumber;
            InitializeComponent();
        }
        ...
    }
