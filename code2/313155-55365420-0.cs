    class RichTextBoxEx : RichTextBox
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, ref Point lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, IntPtr lParam);
        [DllImport("user32")]
        private static extern int GetCaretPos(out Point p);
        const int WM_USER = 0x400;
        const int WM_SETREDRAW = 0x000B;
        const int EM_GETEVENTMASK = WM_USER + 59;
        const int EM_SETEVENTMASK = WM_USER + 69;
        const int EM_GETSCROLLPOS = WM_USER + 221;
        const int EM_SETSCROLLPOS = WM_USER + 222;
        private Point oScrollPoint;
        private bool bPainting = true;
        private IntPtr oEventMask;
        private int iSuspendCaret;
        private int iSuspendIndex;
        private int iSuspendLength;
        private bool bWasAtEnd;
        private Color _selColor = Color.Black;
        public int CaretIndex
        {
            get
            {
                Point oCaret;
                GetCaretPos(out oCaret);
                return this.GetCharIndexFromPosition(oCaret);
            }
        }
        new public Color SelectionColor { get { return _selColor; } set { _selColor = value; } }
        new public void AppendText(string text)  // overwrites RichTextBox.AppendText
        {
            if (this.SelectionStart >= this.TextLength)
            {
                base.SelectionColor = _selColor;
                base.AppendText(text);
            }
            else
            {
                var selStart = this.SelectionStart;
                var selLength = this.SelectionLength;
                SuspendPainting();
                this.Select(this.TextLength, 0);
                base.SelectionColor = _selColor;
                base.AppendText(text);
                this.Select(selStart, selLength);
                ResumePainting();
            }
        }
        private void SuspendPainting()
        {
            if (this.bPainting)
            {
                this.iSuspendCaret = this.CaretIndex;
                this.iSuspendIndex = this.SelectionStart;
                this.iSuspendLength = this.SelectionLength;
                this.bWasAtEnd = this.iSuspendIndex + this.iSuspendLength == this.TextLength;
                SendMessage(this.Handle, EM_GETSCROLLPOS, 0, ref this.oScrollPoint);
                SendMessage(this.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
                this.oEventMask = SendMessage(this.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);
                this.bPainting = false;
            }
        }
        private void ResumePainting()
        {
            if (!this.bPainting)
            {
                if (this.iSuspendLength == 0)
                {
                    if (!bWasAtEnd)
                    {
                        this.Select(this.iSuspendIndex, 0);
                    }
                }
                else
                {
                    // Original selection was to end of text
                    if (bWasAtEnd)
                    {
                        // Maintain end of selection at end of new text
                        this.iSuspendLength = this.TextLength - this.iSuspendIndex;
                    }
                    if (this.iSuspendCaret > this.iSuspendIndex)
                    {
                        // Forward select (caret is at end)
                        this.Select(this.iSuspendIndex, this.iSuspendLength);
                    }
                    else
                    {
                        // Reverse select (caret is at start)
                        this.Select(this.iSuspendIndex + this.iSuspendLength, -this.iSuspendLength);
                    }
                }
                SendMessage(this.Handle, EM_SETSCROLLPOS, 0, ref this.oScrollPoint);
                SendMessage(this.Handle, EM_SETEVENTMASK, 0, this.oEventMask);
                SendMessage(this.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
                this.bPainting = true;
                this.Invalidate();
            }
        }
    }
