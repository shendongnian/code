    public partial class MainForm : Form
    {
        private Thread t1;
        private ThreadStart ts1;
        private ManualResetEvent t1resetEvent;
        public MainForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Got a thread?
            if (t1 != null) {                
                if (!t1.Join(0)) {
                    // The thread seems to be running.
                    // You have to stop the thread first.
                    return;
                }
            }
            t1resetEvent = new ManualResetEvent(false);
            ts1 = new ThreadStart(MyFunc);
            t1 = new Thread(ts1);
            t1.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Got a thread?
            if (t1 != null)
            {
                // Set the reset event so the thread
                // knows it's time to stop.
                t1resetEvent.Set();
                // Give the thread four seconds to stop.
                if (!t1.Join(4000)) {
                    // It did not stop, so abort it. 
                    t1.Abort();
                }
            }
        }
        private void MyFunc()
        {
            // Long running operation...
            while (true)
            {
                // Do someone want us to exit?
                if (t1resetEvent.WaitOne(0)) {
                    return;
                }                
            }
        }
    }
