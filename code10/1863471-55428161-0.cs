    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace temp
    {
        internal static class Program
        {
            [STAThread]
            private static void Main()
            {
                Application.ThreadException += ApplicationOnThreadException;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
    
            private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
            {
                throw new NotImplementedException();
            }
        }
    }
