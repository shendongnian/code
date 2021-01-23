    public delegate void StringArgReturningVoidDelegate(string text);
    public class RichTextBoxWriter : TextWriter
    {
        private readonly RichTextBox _richTextBox;
        public RichTextBoxWriter(RichTextBox richTexttbox)
        {
            _richTextBox = richTexttbox;
        }
        public override void Write(char value)
        {
            SetText(value.ToString());
        }
        public override void Write(string value)
        {
            SetText(value);
        }
        public override void WriteLine(char value)
        {
            SetText(value + Environment.NewLine);
        }
        public override void WriteLine(string value)
        {
            SetText(value + Environment.NewLine);
        }
        public override Encoding Encoding => Encoding.ASCII;
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the  
            // calling thread to the thread ID of the creating thread.  
            // If these threads are different, it returns true.  
            if (_richTextBox.InvokeRequired)
            {
                var d = new StringArgReturningVoidDelegate(SetText);
                _richTextBox.Invoke(d, text);
            }
            else
            {
                _richTextBox.Text += text;
            }
        }
    }
