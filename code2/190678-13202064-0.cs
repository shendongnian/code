    /// <summary>
    /// Extended DateTimePicker with a method to programmatically display the calendar.
    /// </summary>
    class DateTimePickerEx : DateTimePicker
    {
        [DllImport("user32.dll")]
        private static extern bool PostMessage(
        IntPtr hWnd, // handle to destination window
        Int32 msg, // message
        Int32 wParam, // first message parameter
        Int32 lParam // second message parameter
        );
        const Int32 WM_LBUTTONDOWN = 0x0201;
        
        /// <summary>
        /// Displays the calendar input control.
        /// </summary>
        public void ShowCalendar()
        {
            Int32 x = Width - 10;
            Int32 y = Height / 2;
            Int32 lParam = x + y * 0x00010000;
            PostMessage(Handle, WM_LBUTTONDOWN, 1, lParam);
        }
    }
