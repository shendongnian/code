    public static class MessageBox2
    {
        public static DialogResult ShowError(string Caption, string Message, params object[] OptionalFormatArgs)
        {
            return MessageBox.Show(string.Format(Message, OptionalFormatArgs), Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
