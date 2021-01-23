    /// <seealso href="http://msdn.microsoft.com/en-us/library/ms633548(v=vs.85).aspx"/>
        /// <seealso href="http://msdn.microsoft.com/en-us/library/ms633545(v=vs.85).aspx"/>
        public class ShowMessage
        {
            const int SW_SHOWMAXIMIZED = 3; //for maximising (if desired)
            const int SW_SHOW = 5; //for simply activating the form (not needed)
            const int SW_SHOWNORMAL = 1; //displays form at original size and position (what we use here)
            const UInt32 SWP_NOSIZE = 0x0001; //cannot be resized
            const UInt32 SWP_NOMOVE = 0x0002; //cannot be moved
            static readonly IntPtr HWND_TOPMOST = new IntPtr(-1); //always lives at the top
            const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE; //sets the flags for no resize / no move
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
            [DllImport("user32.dll")]
            static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
            /// <summary>
            /// Displays the passed form using the parameters set in the base ShowMessage class
            /// </summary>
            /// <param name="frm">A Windows Form object</param>
            /// <example><code>ShowMessage.ShowTopmost(new myForm());</code></example>
            public static void ShowTopmost(Form frm)
            {
                ShowWindow(frm.Handle, SW_SHOWNORMAL); //shows the form
                SetWindowPos(frm.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS); //sets the form position as topmost, centered
            }
        }
