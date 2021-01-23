    public void SetItemEnabled(ListViewItem item, bool enabled)
    {
      if (item != null)
      {
          List<ListViewControl> lvControls =  this.ListViewControls.FindAll(FindListViewControl(item));
          foreach (ListViewControl lvControl in lvControls)
    	{
    	   if (lvControl.Control != null)
    	   {
    		lvControl.Control.Enabled = enabled;
    	    }
            }
        }
    }
