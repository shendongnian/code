    public class GiveFocusByName : ResultBase
    {
        public GiveFocusByName(string controlToFocus)
    	{
    	    _controlToFocus = controlToFocus;
    	}
    
    	private string _controlToFocus;
    
    	public override void Execute(ActionExecutionContext context)
    	{
    	    var view = context.View as UserControl;
    	    
    
    	    // add support for further controls here
    	    List<Control> editableControls =
    				view.GetChildrenByType<Control>(c => c is CheckBox ||
                                                          c is TextBox ||
                                                          c is Button);
    
            var control = editableControls.SingleOrDefault(c =>
                                                     c.Name == _controlToFocus);
    
            if (control != null)
    		control.Dispatcher.BeginInvoke(() =>
    		{
    		    control.Focus();
    
    		    var textBox = control as TextBox;
    		    if (textBox != null)
    		        textBox.Select(textBox.Text.Length, 0);
    		});
    
    	    RaiseCompletedEvent();
    	}
    }
