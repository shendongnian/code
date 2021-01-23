    using System;
    using System.Text; 
    using System.Windows.Input;
    public void KeyDownSink(object sender, System.Windows.Input.KeyEventArgs e)   
    {  
    	string keyPressed = _keyConv.ConvertToString(e.Key);
 
    	if (keyPressed != null && keyPressed.Length == 1) 
    	{
    		if (char.IsLetterOrDigit(keyPressed[0]))
    		{
    			_textRead.Append(keyPressed[0]);
    		}
    	}
    }
 
    private StringBuilder _textRead = new StringBuilder();   
    private KeyConverter _keyConv = new KeyConverter();
