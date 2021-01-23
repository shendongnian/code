    private static void DisableControl(Control control)
    {
    	PropertyInfo enProp = control.GetType().GetProperty("Enabled");
    	if (enProp != null)
    	{
    		enProp.SetValue(control, false, null);
    	}
    
    	foreach (Control ctrl in control.Controls)
    	{
    		DisableControl(ctrl);
    	}
    }
