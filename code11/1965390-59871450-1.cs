    class ExpandoField : TextBox
    {
        private bool UpdateInProgress = false;
        private static System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(@"\r\n");
        public delegate void CallbackFn();
        CallbackFn VSizeChangedCallback;
        public ExpandoField(CallbackFn VSizeChanged)
        {
            AutoSize = false;
            VSizeChangedCallback = VSizeChanged;
            this.KeyDown += new KeyEventHandler(ExpandoField_KeyDown);
        }
        public void ExpandoField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                this.SelectAll();
        }
        public void UpdateSize()
        {
            if (UpdateInProgress == false && Text.Length > 0)
            {
                UpdateInProgress = true;
                int numLines = 0;
                System.Drawing.Size baseSize = new System.Drawing.Size(Width, Int32.MaxValue);
                System.Drawing.Size lineSize = baseSize;  // compiler thinks we need something here...
                // replace CR/LF with single character (paragraph mark '¶')
                string tmpText = rgx.Replace(Text, "\u00B6");
                // split text at paragraph marks
                string[] parts = tmpText.Split(new char[1] { '\u00B6' });
                numLines = parts.Count();
                foreach (string part in parts)
                {
                    // if the width of this line is greater than the width of the text box, add needed lines
                    lineSize = TextRenderer.MeasureText(part, Font, baseSize, TextFormatFlags.TextBoxControl);
                    numLines += (int) Math.Floor(((double) lineSize.Width / (double) Width));
                }
                if (numLines > 1)
                    Multiline = true;
                else
                    Multiline = false;
                int tempHeight = Margin.Top + (lineSize.Height * numLines) + Margin.Bottom;
                if (tempHeight > Height ||                 // need to grow...
                    Height - tempHeight > lineSize.Height) // need to shrink...
                {
                    Height = tempHeight;
                    VSizeChangedCallback();
                }
                UpdateInProgress = false;
            }
        }
        public override sealed bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            UpdateSize();
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            UpdateSize();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateSize();
        }
    }
