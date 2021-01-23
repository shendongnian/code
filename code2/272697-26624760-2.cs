    public static Control CloneControl(Control c) {
    	var clone = Activator.CreateInstance(c.GetType()) as Control;
    	if (c is HtmlControl) {
    		clone.ID = c.ID;
    		foreach (string key in ((HtmlControl)c).Attributes.Keys)
    			((HtmlControl)clone).Attributes.Add(key, (string)((HtmlControl)c).Attributes[key]);
    	}
    	else {
    		foreach (PropertyInfo p in c.GetType().GetProperties()) {
    			// "InnerHtml/Text" are generated on the fly, so skip them. "Page" can be ignored, because it will be set when control is added to a Page.
    			if (p.CanRead && p.CanWrite && p.Name != "InnerHtml" && p.Name != "InnerText" && p.Name != "Page") {
    				try {
    					p.SetValue(clone, p.GetValue(c, p.GetIndexParameters()), p.GetIndexParameters());
    				}
    				catch {
    				}
    			}
    		}
    	}
    	for (int i = 0; i < c.Controls.Count; ++i)
    		clone.Controls.Add(CloneControl(c.Controls[i]));
    	return clone;
    }
