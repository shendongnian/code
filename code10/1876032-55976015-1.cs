    class NumericOnlyTextBox : TextBox
    {
    	public NumericOnlyTextBox()
    	{
    		this.DefaultStyleKey = typeof(TextBox);
    		TextChanging += NumericOnlyTextBox_TextChanging;
    		Paste += NumericOnlyTextBox_Paste;
    	}
    
    	private void NumericOnlyTextBox_Paste(object sender, TextControlPasteEventArgs e)
    	{
    		//do not allow pasting (or code it yourself)
    		e.Handled = true;
    		return;
    	}
    
    	private void NumericOnlyTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
    	{
    		var matchDecimal = Regex.IsMatch(sender.Text, "^\\d*\\.?\\d*$");
    		var matchInt = Regex.IsMatch(sender.Text, "^\\d*$");
    
    		//default - does it match and int?
    		bool passesTest = matchInt;
    
    		//if not matching an int, does it match decimal if decimal is allowed
    		if (!passesTest && AllowDecimal)
    		{
    			passesTest = matchDecimal;
    		}
    
    		//handle the cursor
    		if (!passesTest && sender.Text != "")
    		{
    			int pos = sender.SelectionStart - 1;
    			sender.Text = sender.Text.Remove(pos, 1);
    			sender.SelectionStart = pos;
    		}
    	}
    
    	protected override void OnApplyTemplate()
    	{
    		base.OnApplyTemplate();
    		InputScope scope = new InputScope();
    		InputScopeName scopeName = new InputScopeName();
    		scopeName.NameValue = InputScopeNameValue.NumberFullWidth;
    		scope.Names.Add(scopeName);
    	}
    
    	public bool AllowDecimal
    	{
    		get { return (bool)GetValue(AllowDecimalProperty); }
    		set { SetValue(AllowDecimalProperty, value); }
    	}
    
    	// Using a DependencyProperty as the backing store for AllowDecimal.  This enables animation, styling, binding, etc...
    	public static readonly DependencyProperty AllowDecimalProperty =
    		DependencyProperty.Register("AllowDecimal", typeof(bool), typeof(NumericOnlyTextBox), new PropertyMetadata(false));
    
    
    }
