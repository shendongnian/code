    public static class WindowExtensions
    {
    	public static void RemoveFocusVisualStyleFromAllExpanders(this Window window)
    	{
    		RecursivelyDelveVisualTreeRemovingFocusVisualStyleFromToggleButtons(window);
    	}
    
    	private static void RecursivelyDelveVisualTreeRemovingFocusVisualStyleFromToggleButtons(DependencyObject d)
    	{
    		var count = VisualTreeHelper.GetChildrenCount(d);
    		for (int i = 0; i < count; i++)
    		{
    			var child = VisualTreeHelper.GetChild(d, i);
    			var toggleButton = child as ToggleButton;
    			if (toggleButton != null)
    			{
    				toggleButton.FocusVisualStyle = null;
    			}
    			else
    			{
    				RecursivelyDelveVisualTreeRemovingFocusVisualStyleFromToggleButtons(child);
    			}
    		}
    	}
    }
