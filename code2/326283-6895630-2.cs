    public const string POST_DATA_EVENT_TARGET = "__EVENTTARGET";
    public const string POST_DATA_EVENT_ARGUMENT = "__EVENTARGUMENT";
    
    /// <summary>
    /// Returns wheather postback has happened due to the given control or not.
    /// </summary>
    public static bool IsPostBackDueToControl(Control control)
    {
    	var postData = HttpContext.Current.Request.Form;
    	string postBackControlName = postData[POST_DATA_EVENT_TARGET];
    	if (control.UniqueID == postBackControlName)
    	{
    		// This is control that has caused postback
    		return true;
    	}
    	if (control is Button ||
    		control is System.Web.UI.HtmlControls.HtmlInputButton)
    	{
    		// Check for button control, button name will be present in post data
    		if (postData[control.UniqueID] != null)
    		{
    			return true;
    		}
    	}
    	else if (control is ImageButton ||
    		control is System.Web.UI.HtmlControls.HtmlInputImage)
    	{
    		// Check for image button, name.x & name.y are returned in post data
    		if (postData[control.UniqueID + ".x"] != null)
    		{
    			return true;
    		}
    	}
    	return false;
    }
