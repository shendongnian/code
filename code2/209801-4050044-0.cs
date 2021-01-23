    var fkEntity = new FK_Entity { ID = 4 };
    var entity = new MyEntity { FK_Entity = fkEntity };
    using (var db = new MyEntities())
    {
        db.AddToEntities(entity);
        ObjectStateEntry fkEntry = db.ObjectStateManager.GetObjectStateEntry(fkEntity);
        // You can check the state here while debugging, but it's probably `Added`
        fkEntity.ChangeState(EntityState.Unchanged);
        db.SaveChanges();
    }
