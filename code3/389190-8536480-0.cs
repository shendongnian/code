    using System;
    using System.Runtime.InteropServices;
    
    class Example
    {
        // Use DllImport to import the Win32 MessageBox function.
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int MessageBox(IntPtr hWnd, String text, 
          String caption, uint type);
    
        public void MessageBox()
        {
            // Call the MessageBox function using platform invoke.
            MessageBox(new IntPtr(0), "Hello World!", "Hello Dialog", 0);
        }
    }
