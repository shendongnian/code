    // Compile using: csc ReadListView.cs /r:UIAutomationClient.dll
    using System;
    using System.Windows.Automation;
    using System.Runtime.InteropServices;
    class ReadListView
    {
        public static void Main()
        {
            Console.WriteLine("Place pointer over listview and hit return...");
            Console.ReadLine();
            // Get cursor position, then the window handle at that point...
            POINT pt;
            GetCursorPos(out pt);
            IntPtr hwnd = WindowFromPoint(pt);
            // Get the AutomationElement that represents the window handle...
            AutomationElement el = AutomationElement.FromHandle(hwnd);
            // Walk the automation element tree using content view, so we only see
            // list items, not scrollbars and headers. (Use ControlViewWalker if you
            // want to traverse those also.)
            TreeWalker walker = TreeWalker.ContentViewWalker;
            int i = 0;
            for( AutomationElement child = walker.GetFirstChild(el) ;
                child != null; 
                child = walker.GetNextSibling(child) )
            {
                // Print out the type of the item and its name
                Console.WriteLine("item {0} is a \"{1}\" with name \"{2}\"", i++, child.Current.LocalizedControlType, child.Current.Name);
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        };
        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(POINT pt);
        [DllImport("user32.dll")]
        private static extern int GetCursorPos(out POINT pt);
    }
 
