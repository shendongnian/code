    // In domain layer:
    MyEntity entity = new MyEntity();
    entity.PrimaryKey = 10;
    entity.Name = "Toby Larone";
    entity.Age = 27;
    
    myDataRepository.Update(entity);
    // In data layer:
    void Update(MyEntity changedEntity)
    {
        using (var db = new DataContext())
        {
            var entity = (from e in db.MyEntities
                          where e.PrimaryKey == changedEntity.PrimaryKey
                          select e).First();
            // Linq2Sql now has change tracking of "entity"... any changes made will be persisted when SubmitChanges is called...
            entity = changedEntity;
            // Linq2Sql does **not** have change tracking of changedEntity - the fact that it has been assigned to the same variable that once stored a tracked entity does not mean that Linq2Sql will magically pick up the changes...
            db.SubmitChanges(); // Nothing happens - as far as Linq2Sql is concerned, the entity that was selected in the first query has not been changed (only the variable in this scope has been changed to reference a different entity).
        }
    }
    
