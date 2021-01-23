	public static System.Collections.Generic.IEnumerable<T> ControlsOfType<T>(this System.Web.UI.Control control) where T: System.Web.UI.Control{
		foreach(System.Web.UI.Control childControl in control.Controls){
			if(childControl is T) yield return (T)childControl;
			foreach(var furtherDescendantControl in childControl.ControlsOfType<T>()) yield return furtherDescendantControl;
		}
	}
