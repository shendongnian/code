    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices; //required for APIs
    namespace Find
    {
    public partial class Form1 : Form
    {
        //Import the FindWindow API to find our window
        [DllImportAttribute("User32.dll")]
        private static extern int FindWindow(String ClassName, String WindowName);
        //Import the SetForeground API to activate it
        [DllImportAttribute("User32.dll")]
        private static extern IntPtr SetForegroundWindow(int hWnd);
        
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Find the window, using the CORRECT Window Title, for example, Notepad
            int hWnd = FindWindow(null, "Untitled - Notepad");
            if (hWnd > 0) //If found
            {
                SetForegroundWindow(hWnd); //Activate it
            }
            else
            {
                MessageBox.Show("Window Not Found!");
            }
      
        }
    }
    }
