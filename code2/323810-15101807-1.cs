    private void RemoveClickEvent(Control control, string theEvent)
    {
    	// chenged "FieldInfo f1 = typeof(Control)" to "var f1 = b.GetType()". By changing to 
    	// the type of the  passed in control we can use this for any control with a click event.
    	// using var allows for null checking and lowering the chance of exceptions.
    	              
		var fi = control.GetType().GetField(theEvent, BindingFlags.Static | BindingFlags.NonPublic);
		if (fi != null)
		{
			object obj = fi.GetValue(control);
			PropertyInfo pi = control.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
			EventHandlerList list = (EventHandlerList)pi.GetValue(control, null);
			list.RemoveHandler(obj, list[obj]);
		}
    	  	
    }
