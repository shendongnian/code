    DataItem itemToUpdate = new DataItem { Id = id, Itemstatus = newStatus };
    dataEntity.Entry(itemToUpdate).Property(x => x.Itemstatus).IsModified = true;
    dataEntity.Configuration.ValidateOnSaveEnabled = false;
    dataEntity.SaveChanges();
    //dataEntity.Configuration.ValidateOnSaveEnabled = true;
