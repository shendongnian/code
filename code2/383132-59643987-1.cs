    private const int EM_SETRECT = 0xB3;
    [DllImport(@"User32.dll", EntryPoint = @"SendMessage", CharSet = CharSet.Auto)]
    private static extern int SendMessageRefRect(IntPtr hWnd, uint msg, int wParam, ref RECT rect);
    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public readonly int Left;
        public readonly int Top;
        public readonly int Right;
        public readonly int Bottom;
        private RECT(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
        public RECT(Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }
    }
    public void SetPadding(TextBox textBox, Padding padding)
    {
        var rect = new Rectangle(padding.Left, padding.Top, textBox.ClientSize.Width - padding.Left - padding.Right, textBox.ClientSize.Height - padding.Top - padding.Bottom);
        RECT rc = new RECT(rect);
        SendMessageRefRect(textBox.Handle, EM_SETRECT, 0, ref rc);
    }
    int MeasureMultilineTextHeigh(string text, Font font, int proposedWidth)
    {
        // Exception handling.
        TextBox textBox = new TextBox()
        {
            Multiline = true,
            BorderStyle = BorderStyle.None,
            Width = proposedWidth,
            Font = font,
        };
        SetPadding(textBox, Padding.Empty);
        textBox.Text = text;
        int lineCount = textBox.GetLineFromCharIndex(int.MaxValue) + 1;
        int fontHeight = TextRenderer.MeasureText("X", font).Height;
        return lineCount * fontHeight;
    }
