    void Main()
    {
    	var t = new TextBox();
    	t.MaxLength=5;
    	t.Text = "123";
    	t.AppendTextRespectMaxLength("456789");
    	t.Text.Dump(); // prints 12345
    }
    
    public static class ExtensionMethods
    {
    	public static void AppendTextRespectMaxLength(this TextBox textbox,string newText)
    	{
    		if(textbox.Text.Length + newText.Length <= textbox.MaxLength)
    		{
    			textbox.Text += newText;
    		}
    		else
    		{
    			var remaining = textbox.MaxLength - textbox.Text.Length;
    			var subPortion = newText.Substring(0,remaining);
    			textbox.Text += subPortion;
    		}
    	}
    }
