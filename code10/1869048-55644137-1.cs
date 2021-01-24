    private static void Main()
    {
        using (var applicationMutex = new Mutex(initiallyOwned: false, name: @"Global\MyGlobalMutex"))
        {
            try
            {
                // check for existing mutex
                if (!applicationMutex.WaitOne(0, exitContext: false))
                {
                    MessageBox.Show("This application is already running!", "Already running",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            // catch abandoned mutex (previos process exit unexpectedly)
            catch (AbandonedMutexException exception) { /* TODO: Handle it */ }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
