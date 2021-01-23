    DataItem itemToUpdate = new DataItem
    {
        Id = id,
        Itemstatus = newStatus,
        NonNullableColumn = "this value is disregarded - the db original will remain"
    };
    dataEntity.Entry(itemToUpdate).Property(x => x.Itemstatus).IsModified = true;
    dataEntity.SaveChanges();
