    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace Integrative.Desktop.Common
    {
        static class NativeMethods
        {
            #region Block input
    
            [DllImport("user32.dll", EntryPoint = "BlockInput")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool BlockInput([MarshalAs(UnmanagedType.Bool)] bool fBlockIt);
    
            public static void HoldUser()
            {
                BlockInput(true);
            }
    
            public static void ReleaseUser()
            {
                BlockInput(false);
            }
    
            public static void DoEventsBlockingInput()
            {
                HoldUser();
                Application.DoEvents();
                ReleaseUser();
            }
    
            #endregion
        }
    }
