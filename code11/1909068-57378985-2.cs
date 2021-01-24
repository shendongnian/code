    public partial class TaskDialog : Form
    {
        ScanInfo info;
        public TaskDialog()
        {
            InitializeComponent();
        }
        public ScanInfo Scan
        {
            get => info;
            set => SetValues(value);
        }
        void SetValues(ScanInfo scan)
        {
            this.info = scan;
            if (info != null)
            {
                this.jobControlTextBox.Text = info.JobControl.ToString();
                this.sheetTextBox.Text = info.Sheet.ToString();
                this.stampDateTimePicker.Text = info.Stamp.ToString();
            }
            else
            {
                this.jobControlTextBox.Clear();
                this.sheetTextBox.Clear();
                this.stampDateTimePicker.Text = DateTime.Now.ToString();
            }
        }
    }
