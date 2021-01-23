    // In domain layer:
    myDataRepository.Update(10, entity =>
    {
        entity.Name = "Toby Larone";
        entity.Age = 27;
    });
    // In data layer:
    void Update(int primaryKey, Action<MyEntity> callback)
    {
        using (var db = new DataContext())
        {
            var entity = (from e in db.MyEntities
                          where e.PrimaryKey == primaryKey
                          select e).First();
            // Linq2Sql now has change tracking of "entity"... any changes made will be persisted when SubmitChanges is called...
            // The changes that were sent are being applied directly to the Linq2Sql entity, which is already under change tracking...
            callback(entity);
            db.SubmitChanges();
        }
    }
