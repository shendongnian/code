    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Runtime.InteropServices;
    
    namespace MID
    {    
        public partial class CustomCursor : Form
        {
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern IntPtr LoadCursorFromFile(string filename);
            
            public CustomCursor()
            {
                InitializeComponent();
    
                Bitmap bmp = (Bitmap)Bitmap.FromFile("Path of the cursor file saved as .bmp");
                bmp.MakeTransparent(Color.Black);
                IntPtr ptr1 = blue.GetHicon();
                
                Cursor cur = new Cursor(ptr1);
                this.Cursor = cur;
                
            }
        }
    }
