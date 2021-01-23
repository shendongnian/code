    public partial class Form1 : Form
    {
        private TestClass _testClass;
        public Form1()
        {
            InitializeComponent();
            _testClass = new TestClass();
            _testClass.OnUpdateStatus += new TestClass.StatusUpdateHandler(UpdateStatus);
        }
        private void UpdateStatus(object sender, ProgressEventArgs e)
        {
            SetStatus(e.Status);
        }
        private void SetStatus(string status)
        {
            label1.Text = status;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
             TestClass.Func();
        }
    }
    public class TestClass
    {
        public delegate void StatusUpdateHandler(object sender, ProgressEventArgs e);
        public event StatusUpdateHandler OnUpdateStatus;
	
        public static void Func()
        {
            //time consuming code
            UpdateStatus(status);
            // time consuming code
            UpdateStatus(status);
        }
	
        private void UpdateStatus(string status)
        {
            // Make sure someone is listening to event
            if (OnUpdateStatus == null) return;
		
            ProgressEventArgs args = new ProgressEventArgs(status);
            OnUpdateStatus(this, args);
        }
    }
    public class ProgressEventArgs : EventArgs
    {
        public readonly string Status { get; private set; }
        public ProgressEventArgs(string status)
        {
            Status = status;
        }
    }
