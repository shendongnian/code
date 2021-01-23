    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<WinText> windows = new List<WinText>();
    
                //find the "first" window
                IntPtr hWnd = FindWindow("notepad", null);
    
                while (hWnd != IntPtr.Zero)
                {
                    //find the control window that has the text
                    IntPtr hEdit = FindWindowEx(hWnd, IntPtr.Zero, "edit", null);
    
                    //initialize the buffer.  using a StringBuilder here
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(255);  // or length from call with GETTEXTLENGTH
    
                    //get the text from the child control
                    int RetVal = SendMessage(hEdit, WM_GETTEXT, sb.Capacity, sb);
    
                    windows.Add(new WinText() { hWnd = hWnd, Text = sb.ToString() });
    
                    //find the next window
                    hWnd = FindWindowEx(IntPtr.Zero, hWnd, "notepad", null);
                }
                
                //do something clever
                windows.OrderBy(x => x.Text).ToList().ForEach(y => Console.Write("{0} = {1}\n", y.hWnd, y.Text));
    
                Console.Write("\n\nFound {0} window(s).", windows.Count);
                Console.ReadKey();
            }
    
            private struct WinText
            {
                public IntPtr hWnd;
                public string Text;
            }
    
            const int WM_GETTEXT = 0x0D;
            const int WM_GETTEXTLENGTH = 0x0E;
    
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
            [DllImport("user32.dll", SetLastError = true)]
            public static extern int SendMessage(IntPtr hWnd, int msg, int Param, System.Text.StringBuilder text);
    
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
    
        }
    }
