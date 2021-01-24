    public void WriteLine(string message)
    {
        if (this.richTextBox1.InvokeRequired)
        {
            var d = new SafeCallDelegate(WriteLine);
            Invoke(d, new object[] { message });
        }
        else
        {
            this.richTextBox1.AppendText(message);
        }
    }
