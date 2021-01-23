    using (var dc = new MyDataContext())
    {
        MyEntity entity = new MyEntity();
         
        dc.MyEntities.InsertOnSubmit(entity);
        dc.SubmitChanges();
         
        int pkValue = entity.PKColumn
    }
