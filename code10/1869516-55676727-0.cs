    class myRTB : RichTextBox
    {
        public myRTB()
        {
            this.Multiline = true;
            this.ScrollBars = RichTextBoxScrollBars.Vertical;
        }
        public myRTB Buddy { get; set; }
        private static bool scrolling;   // In case buddy tries to scroll us
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            // Trap WM_VSCROLL message and pass to buddy
            if (m.Msg == 0x115 && !scrolling && Buddy != null && Buddy.IsHandleCreated)
            {
                scrolling = true;
                synchTopLineRel(Buddy);
                scrolling = false;
            }
        }
        void synchTopLineRel(RichTextBox rtb)
        {
            int i0 = GetCharIndexFromPosition(Point.Empty);
            int i1 = GetLineFromCharIndex(i0);
            int i2 = (int)(i1 * Buddy.Lines.Length / Lines.Length);
            // the rest scrolls to line # i2..:
            int bss = Buddy.SelectionStart;
            int bsl = Buddy.SelectionLength;
            Buddy.SelectionStart = Buddy.GetFirstCharIndexFromLine(i2);
            Buddy.ScrollToCaret();
            Buddy.SelectionStart = bss;
            Buddy.SelectionLength = bsl;
        }
    }
