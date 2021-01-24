    public class TextBoxStreamWriter : TextWriter
    {
    	TextBox _output;
    
    	public TextBoxStreamWriter(TextBox output)
    	{
    		_output = output;
    	}
    
    	public override void Write(char value)
    	{
    		MethodInvoker action =
    			delegate
    			{
    				_output.AppendText(value.ToString());
    				if (_output.Text.Length > 4000)
    					_output.Text = _output.Text.Substring(2000, _output.Text.Length - 2000);
    			};
    		_output.BeginInvoke(action);
    	}
    
    	public override Encoding Encoding
    	{
    		get { return System.Text.Encoding.UTF8; }
    	}
    }
