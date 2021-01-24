    class Form1 : Form
    {
        protected readonly CancellationTokenSource _cts;
        protected readonly Thread _thread;
        public Form1()
        {
            InitializeComponent();
            _cts = new CancellationTokenSource();
            _thread = new Thread(ThreadFunc);
            _thread.Start();
        }
        private void ThreadFunc()
        {
            try
            {
                while (true)
                {
                    // Do stuff here
                    Task.Delay(40, _cts.Token).GetAwaiter().GetResult();
                }
            }
            catch (OperationCanceledException)
            {
                // Ignore cancellation exception
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
            this.Visible = false; // Hide the form before blocking the UI
            _thread.Join(5000); // Wait the thread to finish, but no more than 5 sec
            this.Close();
        }
    }
