    public interface IMessageLoopTestRunner
    {
        void Finish();
    }
    public class MessageLoopTestRunner : Form, IMessageLoopTestRunner
    {
        public static void Run(Action<IMessageLoopTestRunner> test, TimeSpan timeout)
        {
            Application.Run(new MessageLoopTestRunner(test, timeout));
        }
        private readonly Action<IMessageLoopTestRunner> test;
        private readonly Timer timeoutTimer;
        private MessageLoopTestRunner(Action<IMessageLoopTestRunner> test, TimeSpan timeout)
        {
            this.test = test;
            this.timeoutTimer = new Timer
            {
                Interval = (int)timeout.TotalMilliseconds, 
                Enabled = true
            };
                
            this.timeoutTimer.Tick += delegate { this.Timeout(); };
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // queue execution of the test on the message queue
            this.BeginInvoke(new MethodInvoker(() => this.test(this)));
        }
        private void Timeout()
        {
            this.Finish();
            throw new Exception("Test timed out.");
        }
        public void Finish()
        {
            this.timeoutTimer.Dispose();
            this.Close();
        }
    }
