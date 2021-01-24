    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            [DllImport("user32.dll")]
            public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);
    
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                const uint WDA_NONE = 0;
                const uint WDA_MONITOR = 1;
                SetWindowDisplayAffinity(this.Handle, WDA_MONITOR);
            }
        }
    }
