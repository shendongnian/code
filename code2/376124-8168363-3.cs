		public static Window GetWindowFromPoint(Point point)
		{
			var hwnd = NativeMethods.WindowFromPoint(new POINT((int)point.X, (int)point.Y));
			if(hwnd == IntPtr.Zero) return null;
			var p = NativeMethods.GetParent(hwnd);
			while(p != IntPtr.Zero)
			{
				hwnd = p;
				p = NativeMethods.GetParent(hwnd);
			}
			foreach(Window w in Application.Current.Windows)
			{
				if(w.IsVisible)
				{
					var helper = new WindowInteropHelper(w);
					if(helper.Handle == hwnd) return w;
				}
			}
			return null;
		}
		public static Window GetWindowFromMousePosition()
		{
			POINT p = new POINT();
			NativeMethods.GetCursorPos(ref p);
			return GetWindowFromPoint(new Point(p.x, p.y));
		}
