    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        static class Program
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
                    void GenerateForm()
                    {
                        Random r = new Random();
    
                        Form testform = new Form()
                        {
                            BackColor = Color.FromArgb(r.Next(r.Next(0, 255), 255), r.Next(r.Next(0, 255), 255), r.Next(r.Next(0, 255), 255)),
                            FormBorderStyle = FormBorderStyle.None
                        };
    
                        testform.MouseDown += (s, me) =>
                        {
                            if (me.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(testform.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); }
                        };
    
                        testform.FormClosed += (s, fe) =>
                        {
                            if (Application.OpenForms.Count == 0)
                            {
                                ExitThread();
                            }
                        };
    
                        testform.Controls.Add(new FlatClose());
    
                        Button butt = new Button() 
                        { 
                            Location = new Point(60, 0),
                            Size = new Size(200, 20),
                            Text = "Make Another Form"
                        };
    
                        butt.Click += (s, be) => GenerateForm();
    
                        testform.Controls.Add(butt);
    
                        testform.Show();
                    }
    
                    for (int i = 0; i < 3; i++) { GenerateForm(); }
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
