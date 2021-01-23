    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TestClass.progress += SetStatus;
        }
        private void SetStatus(object sender, Progress e)
        {
            label1.Text = e.Status;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
             TestClass.Func();
        }
     }
     
    public class TestClass
    {
        public static event EventHandler<Progress> progress; 
        
        public static void Func()
        {
            //time consuming code
            OnProgress(new Progress("current status"));
            // time consuming code
            OnProgress(new Progress("some new status"));            
        }
        private static void OnProgress(EventArgs e) 
        {
           if (progress != null)
              progress(this, e);
        }
    }
    
    
    public class Progress : EventArgs
    {
        public string Status { get; private set; }
        private Progress() {}
        public Progress(string status)
        {
            Status = status;
        }
    }
