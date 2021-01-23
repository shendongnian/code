	/// <summary>
	/// Appends CSS Class seprated by a space character
	/// </summary>
	/// <param name="control">Target control</param>
	/// <param name="cssClass">CSS class name to append</param>
	public static void AppendCss(HtmlGenericControl control, string cssClass)
	{
		// Ensure CSS class is definied
		if (string.IsNullOrEmpty(cssClass)) return;
		// Append CSS class
		if (string.IsNullOrEmpty(control.Attributes["class"]))
		{
			// Set our CSS Class as only one
			control.Attributes["class"] = cssClass;
		}
		else
		{
			// Append new CSS class with space as seprator
			control.Attributes["class"] += (" " + cssClass);
		}
	}
