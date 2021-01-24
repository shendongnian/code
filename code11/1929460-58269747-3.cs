    class Form1 : Form
    {
        protected readonly CancellationTokenSource _cts;
        protected readonly Task _task;
        public Form1()
        {
            InitializeComponent();
            _cts = new CancellationTokenSource();
            _task = Task.Run(TaskFunc);
            this.FormClosing += Form_FormClosing;
        }
        private async Task TaskFunc()
        {
            try
            {
                while (true)
                {
                    // Do async stuff here, using _cts.Token if possible
                    // The stuff will run in thread-pool threads
                    await Task.Delay(40, _cts.Token).ConfigureAwait(false);
                }
            }
            catch (OperationCanceledException)
            {
                // Ignore cancellation exception
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_task == null || _task.IsCompleted) return;
            e.Cancel = true;
            _cts.Cancel();
            this.Visible = false; // Or give feedback that the form is closing
            var completedTask = await Task.WhenAny(_task, Task.Delay(5000));
            if (completedTask != _task) Debug.WriteLine("Task refuses to die");
            _task = null;
            await Task.Yield(); // To ensure that Close won't be called synchronously
            this.Close(); // After await we are back in the UI thread
        }
    }
