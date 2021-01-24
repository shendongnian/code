    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace iMouse
    {
        public partial class Events : Form
        {
            public Thread TrackerThread;
            public Mutex Checking = new Mutex(false);
            public AutoResetEvent Are = new AutoResetEvent(false);
            public Events()
            {
                InitializeComponent();
            }
            private void Events_Load(object sender, EventArgs e)
            {
                CheckForIllegalCrossThreadCalls = false;
            }
            public void Button3_Click(object sender, EventArgs e)
            {
                Visible = false;
                MouseTracker();
            }
            private void MouseTracker()
            {
                if (Checking.WaitOne(10))
                {
                    var ctx = new SynchronizationContext();
                    Are.Reset();
                    TrackerThread = new Thread(() =>{
                           while (true)
                           {
                               if (Are.WaitOne(1))
                               {
                                   break;
                               }
                               if (MouseButtons == MouseButtons.Left)
                               {
                                   ctx.Send(CLickFromOutside, null);
                                   break;
                               }
                           }
                       }
                    );
                    TrackerThread.Start();
                    Checking.ReleaseMutex();
                }
            }
    
            private void CLickFromOutside(object state)
            {
                Are.Set();
                int X = MousePosition.X;
                int Y = MousePosition.Y;
                TextBox2.Text = X.ToString();
                TextBox3.Text = Y.ToString();
                Visible = true;
            }
        }
    }
