    // Make sure you have the correct using clause to see DllImport:
    // using System.Runtime.InteropServices;
     [DllImport("user32.dll")]
        private static extern int SendMessage (IntPtr hWnd, int wMsg, int wParam, 
            int lParam);
