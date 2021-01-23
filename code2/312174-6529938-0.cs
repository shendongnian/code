    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace ProcessWindows
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll")]
            static extern bool SetForegroundWindow(IntPtr hWnd);
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("notepad");
                if (p.Length > 0)
                {
                    SetForegroundWindow(p[0].MainWindowHandle);
                }
            }
        }
    }
