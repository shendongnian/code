    public static Control CloneControl(Control c) {
    	Control clone = Activator.CreateInstance(c.GetType()) as Control;
    	foreach (PropertyInfo p in c.GetType().GetProperties()) {
            // "InnerHtml/Text" are generated on the fly, so skip them. "Page" can be ignored, because it will be set when control is added to a Page.
            if (p.CanRead && p.CanWrite && p.Name != "InnerHtml" && p.Name != "InnerText" && p.Name != "Page") {
                try {
                    p.SetValue(clone, p.GetValue(c, p.GetIndexParameters()), p.GetIndexParameters());
                }
                catch (System.Exception) {
                }
            }
    	}
    	for (int i = 0; i < c.Controls.Count; ++i)
    		clone.Controls.Add(CloneControl(c.Controls[i]));
    	return clone;
    }
