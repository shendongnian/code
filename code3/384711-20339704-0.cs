    bool? IsFontSet = null;
    
    try {
    	Type t = typeof(Control);
    	System.Reflection.MethodInfo mi = t.GetMethod("IsFontSet", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    	if (mi != null) {
    		IsFontSet = (bool?) mi.Invoke(view, null);
    	}
    } catch {}
