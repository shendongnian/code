    using System;
    using System.Windows.Forms;
    
    namespace Client
    {
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
                var engine1 = new Engine.Engine1();
                Application.Run(new Form1());
            }
        }
    }
