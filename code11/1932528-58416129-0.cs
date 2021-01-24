c#
    public void Insert(ProjectDto item)
    {
      using (var ctx = ObjectContextManager<PTrackerEntities>.GetManager("PTrackerEntities"))
      {
        var newItem = new Project
        {
          Name = item.Name,
          Description = item.Description,
          Started = item.Started,
          Ended = item.Ended
        };
        ctx.ObjectContext.AddToProjects(newItem);
        ctx.ObjectContext.SaveChanges();
        item.Id = newItem.Id;
        item.LastChanged = newItem.LastChanged;
      }
    }
