    public void Set(TaskPrice entity)
    {
        ObjectStateEntry entry=null;
        if (this.Context.ObjectStateManager.TryGetObjectStateEntry(entity, out entry) == false)
        {
            this.ObjectSet.Attach(entity);
        }
        bool isExists = GetQuery().Any(x => x.TaskId == entity.TaskId);
        if (isExists)
        {
		    this.Context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }
        else
        {
		    this.ObjectSet.AddObject(entity);
        }
    }
