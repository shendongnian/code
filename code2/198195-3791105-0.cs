	public static string[] GetCurrentUserControlPaths() {
		if(HttpContext.Current == null) return new string[0];
		if(!(HttpContext.Current.Handler is Page)) return new string[0];
		
		var page = (HttpContext.Current.Handler as Page);
		var paths = ControlAggregator(page, c => c is UserControl).Cast<UserControl>().Select(uc => uc.AppRelativeVirtualPath);
		
		if(page.Master != null) {
			paths.Concat(ControlAggregator(page.Master, c => c is UserControl).Cast<UserControl>().Select(uc => uc.AppRelativeVirtualPath));
		}
	
		return paths.ToArray();
	}
						
	public static Control[] ControlAggregator(this Control control, Func<Control, bool> selector) {
		var list = new List<Control>();
	
		if (selector(control)) {
			list.Add(control);
		}
		
		foreach(Control child in control.Controls) {
			list.AddRange(ControlAggregator(child, selector));
		}
	
		return list.ToArray();
	}
