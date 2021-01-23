    public void UpdateUser(UserData userData)
    {
       using (mEntities context = new mEntities())
       {
         UnitOfWork uow = new UnitOfWork(context);
         User usr = new User(); //This is the Entity Framework class
         usr.ID = userData.RowID;
         usr.UserName = userData.Username;   //usr.UserName is the primary key in the table
    
         uow.Users.UpdateRow(usr);
         //uow.Commit();
       }
    }
