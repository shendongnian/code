    using System;
    using System.Runtime.InteropServices;
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
            private const int WM_NCLBUTTONDOWN = 0xA1,
                                    HT_CAPTION = 0x2;
    
            [DllImport("user32.dll")]
            private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    
            [DllImport("user32.dll")]
            private static extern bool ReleaseCapture();
    
            class MultipleFormsOpen : ApplicationContext
            {
                public MultipleFormsOpen()
                {
                    Form1 mainform = new Form1();
    
                    mainform.MouseDown += (s, me) =>
                    {
                        if (me.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(mainform.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); }
                    };
    
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
