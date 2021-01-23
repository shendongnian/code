    using (var context = new MyDataContext())
    {
        // Note: Attatch to the entity:
        context.MyTableEntity.Attach(EntityToRemove);
        context.MyTableEntity.Remove(EntityToRemove);
        var nrOfObjectsChanged = context.SaveChanges();
    }
