    public void SaveTask ( Task task )
    {
    	if (task.tasksId == 0)
    	{
    		dc.TaskTable.InsertOnSubmit(task);
    	} else
    	{
    		dc.TaskTable.Context.Refresh(RefreshMode.KeepCurrentValues , task);
    	}
    	dc.SubmitChanges();
    }
