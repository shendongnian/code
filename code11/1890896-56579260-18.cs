    using System;
    using System.Windows.Forms;
    
    namespace Client
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var clientAction = new ClientAction();
                var engine1 = new Engine.Engine1();
                Application.Run(new Form1());
            }
        }
    }
