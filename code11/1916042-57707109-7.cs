    using System;
    using System.Threading;
    using System.Windows.Forms;
    namespace WindowsFormsApp3
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using (var form = new Form1())
                {
                    form.SomeEvent += onSomeEvent;
                    Application.Run(form);
                }
            }
            static void onSomeEvent(object sender, EventArgs e)
            {
                Thread.Sleep(4000);
            }
        }
    }
