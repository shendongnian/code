    using ManagedWinapi.Windows;
    using System;
    namespace TestApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create a SystemWindow object from the HWND of the ListView
                SystemWindow lvWindow = new SystemWindow((IntPtr)0x6d1d38);
                // Create a ListView object from the SystemWindow object
                var lv = SystemListView.FromSystemWindow(lvWindow);
                // Read text from a row
                var text = lv[0].Title;
            }
        }
    }
