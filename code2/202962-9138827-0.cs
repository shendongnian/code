    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace MyApplication
    {
        public partial class Form1 : Form
        {
            [DllImport("uxtheme", ExactSpelling = true, CharSet = CharSet.Unicode)]
            public extern static Int32 SetWindowTheme(IntPtr hWnd,
                          String textSubAppName, String textSubIdList);
    
            public Form1()
            {
                InitializeComponent();
    
                // Remove Win7 formatting from the progress bar.
                SetWindowTheme(progressBar1.Handle, "", "");
 
