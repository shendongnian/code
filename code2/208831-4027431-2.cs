    public static class Extensions
    {
        public static void StyleText(this RichTextBox me, string text, FontStyle style)
        {
            int curPos = me.SelectionStart;
            int selectLen = me.SelectionLength;
            int len = text.Length;
            int i = me.Text.IndexOf(text);
            while (i >= 0)
            {
                me.Select(i, len);
                me.SelectionFont = new Font(me.Font, style);
                i = me.Text.IndexOf(text, i + len);
            }
            me.SelectionStart = curPos;
            me.SelectionLength = selectLen;
        }
    }
