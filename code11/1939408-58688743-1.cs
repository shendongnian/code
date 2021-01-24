        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form1 frm1 = new Form1();
                //If you really need to go down this road read up on what this is doing
                Control.CheckForIllegalCrossThreadCalls = false;
                new Thread(new ThreadStart(() =>
                {
                    Random rng = new Random();
                    while(true)
                    {
                        frm1.Size = new System.Drawing.Size(rng.Next(50, 1000), rng.Next(50, 1000));
                        Thread.Sleep(2000);
                    }
                })).Start();
                Application.Run(frm1);
            }
        }
