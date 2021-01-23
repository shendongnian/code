    //Perform Update
    using (PriorityOneEntities entities = new PriorityOneEntities())
    {
        entities.Entry(userInfo).State = EntityState.Modified;
        entities.SaveChanges();
    }
