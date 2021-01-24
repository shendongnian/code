    class CustomCombobox : ComboBox
    {
    	internal bool IsEditableFocusTextBox { get; set; }
    	public override void OnApplyTemplate()
    	{
    		base.OnApplyTemplate();
    		if (IsFocused && IsEditable && IsEditableFocusTextBox)
    		{
    			TextBox myControl = (TextBox)GetTemplateChild("PART_EditableTextBox");
    			if (myControl != null)
    			{
    				myControl.Focus();
    			}
    		}
    	}
    }
