    /// <summary>
    /// Set the DisplayMode of a given ListViewItem.
    /// </summary>
    /// <param name="item">The given ListViewItem.</param>
    /// <param name="displayMode">The DisplayMode to set.</param>
    public void SetItemDisplayMode(ListViewItem item, DisplayMode displayMode)
    {
    	if (item != null)
    	{
    	   List<ListViewControl> lvControls = this.ListViewControls.FindAll(FindListViewControl(item));
    	   foreach (ListViewControl lvControl in lvControls)
    	   {
    		if (lvControl.Control is IDisplay)
    		{
    		   ((IDisplay)lvControl.Control).DisplayMode = displayMode;
    		}
    	   }
        }
    }
