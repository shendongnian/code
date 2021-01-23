    // In data layer:
    void Update(MyEntity changedEntity)
    {
        using (var db = new DataContext())
        {
            var entity = (from e in db.MyEntities
                          where e.PrimaryKey == changedEntity.PrimaryKey
                          select e).First();
            // Linq2Sql now has change tracking of "entity"... any changes made will be persisted when SubmitChanges is called...
            entity.ApplyChanges(changedEntity);
            db.SubmitChanges(); // Works OK...
        }
    }
