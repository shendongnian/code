    public void EditUser(user user, Roles role)
    {
        using (TestEntities entities = new TestEntities())
        {
            entities.Connection.Open();
            using (DbTransaction trans = entities.Connection.BeginTransaction())
            {
              InnerEditUser(entities, trans);
              InnerThat(entities, trans);
              InnerThis(entities,trans);
              entities.SaveChanges();
              trans.Commit();
            }
        }
     }
