    using (var context = new MyDataContext())
    {
        context.MyTableEntity.Remove(EntytyToRemove);
        var nrOfObjectsChanged = context.SaveChanges();
    }
