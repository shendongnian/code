    public static void UpdateBinding()
    {
    	UpdateBinding(Keyboard.FocusedElement as TextBox);
    }
    
    public static void UpdateBinding(TextBox element)
    {
    	if (element != null) 
    	{
    		var binding = element.GetBindingExpression(TextBox.TextProperty);
    		if (binding != null) 
    		{
    			binding.UpdateSource();
    		}
    	}
    }
