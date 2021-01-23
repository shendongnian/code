    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Threading;
    namespace TwoWindows
    {
        static class Program
        {
            public static Form1 form1;
            public static Form2 form2;
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false); 
                form1 = new Form1();
                form2 = new Form2();
                form1.Form2Property = form2;
                form2.Form1Property = form1;
                form1.Show();
                form2.Show();
                Application.Run();
            }
        }
    }
