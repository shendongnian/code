    public class MyControl : Control
    {
        private int m_cursorPos = 0;
        public MyControl()
        {
            Text = string.Empty;
            CursorPos = 0;
        }
        private int CursorPos 
        { 
            get { return m_cursorPos; } 
            set
            {
                if(value < 0) value = 0;
                if(value > Text.Length) value = Text.Length;
                m_cursorPos = value;
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                    if (CursorPos > 0)
                    {
                        CursorPos--;
                        Text = Text.Remove(CursorPos, 1);
                    }
                    break;
                case Keys.Delete:
                    if (CursorPos < Text.Length - 1)
                    {
                        Text = Text.Remove(CursorPos, 1);
                    }
                    break;
                case Keys.Left:
                    CursorPos--;
                    break;
                case Keys.Right:
                    CursorPos++;
                    break;
                default:
                    base.OnKeyDown(e);
                    break;
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) 
                   || char.IsSymbol(e.KeyChar) 
                   || char.IsPunctuation(e.KeyChar) 
                   || char.IsWhiteSpace(e.KeyChar))
            {
                Text = Text.Insert(CursorPos, char.ToString(e.KeyChar));
                CursorPos++;
                Debug.WriteLine(this.Text);
            }
        }
    }
