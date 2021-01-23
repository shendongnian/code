    static class Program
    {
        private static volatile bool _exitProcess;
    
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            var showMeEventHandle = new EventWaitHandle(false, EventResetMode.AutoReset, "MyApp.ShowMe", out createdNew);
    
            if (createdNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var form = new Form1();
                new Thread(() =>
                {
                    while (!_exitProcess)
                    {
                        showMeEventHandle.WaitOne(-1);
                        if (!_exitProcess)
                        {
                            if (form.InvokeRequired)
                            {
                                form.BeginInvoke((MethodInvoker)form.BringFormToFront);
                            }
                            else
                            {
                                form.BringFormToFront();
                            }
                        }
                    }
                }).Start();
    
                Application.Run(form);
            }
    
            _exitProcess = true;
            showMeEventHandle.Set();
    
            showMeEventHandle.Close();
        }
    }
