    ///RadonCodeEditor is the name of Project
        /// <summary>
        /// Gets or sets a value whether RadonTextEditor should repaint itself.
        /// </summary>
        public bool Repaint = true;
    cKeyword=Color.Blue;
    cComment=Color.Green;
        /// <summary>
        /// A Windows generated message send to a control that needs repainting.
        /// </summary>
        const short WM_PAINT = 0x00f;
        /// <summary>
        /// Contains creation data to call RadonTextEditor.
        /// </summary>
        public RadonTextEditor()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//Reduces flickering.
        }
        /// <summary>
        /// Overrides default WndProc and handles WM_PAINT message to remove flickering.
        /// </summary>
        /// <param name="m">The message in message queue.</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PAINT)//If the message in the message queue is WM_PAINT.
            {
                switch (Repaint)
                {
                    case true://When we want RadonTextEditor to repaint.
                        base.WndProc(ref m);
                        break;
                    case false://When we don't want RadonTextEditor to repaint.
                        m.Result = IntPtr.Zero;
                        break;
                }
            }
            else//If the message in the message queue is anything else but not WM_PAINT.
            {
                base.WndProc(ref m);
            }
        }
    //Import namespace System.Text.RegularExpressions
     /// <summary>
        /// Checks the input text for any contained comments using a defined Regular Expression.
        /// </summary>
        /// <param name="Text">The text to check.</param>
        /// <param name="FirstCharIndex">The first character index of current line.</param>
        /// <param name="CaretPosition">The position of caret.</param>
        /// <param name="rtb">The handle to RichTextBox for highlighting.</param>
        /// <returns>If the input text contains any text the return value is true otherwise false.</returns>
        public void IsComment(string Text, int FirstCharIndex, int CaretPosition, RichTextBox rtb)
        {
            rComment = new Regex(@"\/\/.*$", RegexOptions.Compiled);
            MatchCollection Matches = rComment.Matches(Text);
            foreach (Match match in Matches)
            {
                rtb.Select(match.Index + FirstCharIndex, match.Length);
                rtb.SelectionColor = cComment;
                rtb.DeselectAll();
                rtb.SelectionStart = CaretPosition;
            }
            rMultiComment = new Regex(@"/\*.*?\*/", RegexOptions.Multiline);
            MatchCollection Matches2 = rMultiComment.Matches(Text);
            foreach (Match match2 in Matches2)
            {
                rtb.Select(match2.Index + FirstCharIndex, match2.Length);
                rtb.SelectionColor = cComment;
                rtb.DeselectAll();
                rtb.SelectionStart = CaretPosition;
            }
        }
        /// <summary>
        /// Checks the input text for any contained keywords using a defined Regular Expression.
        /// </summary>
        /// <param name="Text">The text to check.</param>
        /// <param name="FirstCharIndex">The first character index of current line.</param>
        /// <param name="CaretPosition">The position of caret.</param>
        /// <param name="rtb">The handle to RichTextBox for highlighting.</param>
        /// <returns>If the input text contains any text the return value is true otherwise false.</returns>
        public void IsKeyword(string Text, int FirstCharIndex, int CaretPosition, RichTextBox rtb)
        {
            rKeyword = new Regex(@:\bint\b|\bdouble\b|\bstring\b", RegexOptions.Compiled);
            MatchCollection Matches = rKeyword.Matches(Text);
            foreach (Match match in Matches)
            {
                rtb.Select(match.Index + FirstCharIndex, match.Length);
                rtb.SelectionColor = cKeyword;
                rtb.DeselectAll();
                rtb.SelectionStart = CaretPosition;
            }
        }
