    public static Control CloneControl(Control c) {
    	Control clone = Activator.CreateInstance(c.GetType()) as Control;
    	foreach (PropertyInfo p in c.GetType().GetProperties()) {
    		if (p.CanRead && p.CanWrite)
    			p.SetValue(clone, p.GetValue(c, p.GetIndexParameters()), p.GetIndexParameters());
    	}
    	for (int i = 0; i < c.Controls.Count; ++i)
    		clone.Controls.Add(CloneControl(c.Controls[i]));
    	return clone;
    }
