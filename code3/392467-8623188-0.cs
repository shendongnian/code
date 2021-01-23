    class MyTraceListener : TraceListener
    {
    TextBox textBox;
    public MyTraceListener(TextBox textBox)
    {
    this.textBox = textBox;
    }
    
    public override void Write(string value)
    {
    this.textBox.AppendText(value);
    }
    
    }
