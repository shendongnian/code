    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent(); // fileProgress1 setup. 
        }
        private void StartTask()
        {
            Task t1 = new Task(BackgroundMethod1, fileProgress1); // Explicitly pass a reference to the progress bar.
            Task t2 = new Task(BackgroundMethod2); // Use a method that has access to the bar.
            Task t5 = new Task(BackgroundMethod3, IncrementPBMethod); // Pass an action to the background method. Abstracting the physical progress bar as something where you can set the progress.
            Task t4 = new Task(delegate() { /* fileProgress1 referened*/ }); // Create a closure. I don't recommend this method.
        }
        private static void BackgroundMethod1(ProgressBar pb)
        {
            for(int i = 0; i < 100; ++i)
            {
                if(pb.InvokeRequired)
                {
                    pb.Invoke(delegate() { pb.Value = i; });
                }
                Thread.Sleep(1000);
            }
        }
        private void BackgroundMethod2()
        {
            for(int i = 0; i < 100; ++i)
            {
                if(fileProgress1.InvokeRequired)
                {
                    fileProgress1.Invoke(delegate() { fileProgress1.Value = i; });
                }
                Thread.Sleep(1000);
            }
        }
        private static BackgroundMethod3(Action<int> setProgress)
        {
            for(int i = 0; i < 100; ++i)
            {
                setProgress(i);
                Thread.Sleep(1000);
            }
        }
        private void IncrementPBMethod(int value)
        {
            if(fileProgress1.InvokeRequired)
            {
                fileProgress1.Invoke(IncrementPBMethod, value);
            }
            else
            {
                fileProgress1.Value = value;
            }
        }
    }
