        // Convert the unit used by the .NET framework (1/100 inch) 
        // and the unit used by Win32 API calls (twips 1/1440 inch)
        private const double anInch = 14.4;
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct CHARRANGE
        {
            public int cpMin;				// First character of range (0 for start of doc)
            public int cpMax;				// Last character of range (-1 for end of doc)
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct FORMATRANGE
        {
            public IntPtr    hdc;			// Actual DC to draw on
            public IntPtr    hdcTarget;		// Target DC for determining text formatting
            public RECT      rc;			// Region of the DC to draw to (in twips)
            public RECT      rcPage;		// Region of the whole DC (page size) (in twips)
            public CHARRANGE chrg;			// Range of text to draw (see earlier declaration)
        }
        private const int WM_USER        = 0x0400;
        private const int EM_FORMATRANGE = WM_USER + 57;
        [DllImport("USER32.dll")] private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
		/// <summary>
		/// Render the specified RichTextBox onto the specified bitmap
		/// </summary>
		/// <param name="textBox">RichTextBox to render</param>
		/// <param name="bitmap">Bitmap to render the RichTextBox onto</param>
        public void RenderToBitmap(RichTextBox textBox, Bitmap bitmap)
        {
            // Set area to render to be entire bitmap
            RECT rect;
            rect.Left   = 0;
            rect.Top    = 0;
            rect.Right  = (int)(bitmap.Width  * anInch);
            rect.Bottom = (int)(bitmap.Height * anInch);
			Graphics g   = Graphics.FromImage(bitmap);
            IntPtr   hdc = g.GetHdc();
            FORMATRANGE fmtRange;
            fmtRange.chrg.cpMin = textBox.GetCharIndexFromPosition(new Point(0,0));
            fmtRange.chrg.cpMax = textBox.GetCharIndexFromPosition(new Point(bitmap.Width,bitmap.Height));
            fmtRange.hdc        = hdc;					// Use the same DC for measuring and rendering
            fmtRange.hdcTarget  = hdc;
            fmtRange.rc         = rect;
            fmtRange.rcPage     = rect;
            IntPtr lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange));
            Marshal.StructureToPtr(fmtRange, lparam, false);
            // Render the control to the bitmap
            SendMessage(textBox.Handle, EM_FORMATRANGE, new IntPtr(1), lparam);
            // Clean up
            Marshal.FreeCoTaskMem(lparam);
            g.ReleaseHdc(hdc);
        }
