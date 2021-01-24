    public String GetNewKey()
    {
    	String _string_key = String.Empty;
    	Guid _guid = Guid.NewGuid();
    	foreach (char _char in Convert.ToBase64String(_guid.ToByteArray()))
    	{
    		_string_key += char.IsLetterOrDigit(_char) ? _char.ToString() : string.Empty;
    	}
    	return _string_key;
    }
    
    public void RunScript(String _script)
    {
    	String function = @"<script type='text/javascript'> $(function () { " + _script + " }); </script>";
    	this.ClientScript.RegisterStartupScript(_page.GetType(), Utilities.GetNewKey(), function, false);
    }
