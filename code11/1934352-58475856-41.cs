    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        static class Form_Helper
        {
            public static void Generic_FormClosed(object sender, FormClosedEventArgs e)
            {
                if (Application.OpenForms.Count == 0) { Application.ExitThread(); }
            }
        }
        
        class Program
        {
            class MultipleFormsOpen : ApplicationContext
            {
                public MultipleFormsOpen()
                {
                    Form1 mainform = new Form1();
                    mainform.Show();
                }
            }
    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MultipleFormsOpen());
            }
        }
    }
