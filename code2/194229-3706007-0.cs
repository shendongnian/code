    foreach (Control c in form/containerObject.Controls) {
    	if ("TextBox" == c.GetType()) {
    		TextBox tb = c as TextBox;
    		if (tb.Length > 0) {
    			newEmployee/targetObject.Title = HttpUtility.HtmlEncode(tb.Text);
    		}
    	}
    }
