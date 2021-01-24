    public void DoSomething(AppEntity someEntity)
    {
        using(var context = new AppContext())
        {
            someEntity.Status = "DidSomething";
            context.Attach(someEntity);
            context.Entity(someEntity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
