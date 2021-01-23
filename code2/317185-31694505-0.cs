    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class Form1 : Form
    {
	    [DllImport("User32.dll", CharSet = CharSet.Ansi, SetLastError = true,    ExactSpelling = true)]
	    private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool Repaint);
	    private void Form1_Load(System.Object sender, System.EventArgs e)
    	{
		    this.MaximumSize = new Size(5000, 800);
     		bool Result = MoveWindow(this.Handle, this.Left, this.Top, 5000, 500, true);
	    }
	    public Form1()
	    {
		    Load += Form1_Load;
	    }
    }
