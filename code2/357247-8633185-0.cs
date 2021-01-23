    public void UpdateUser(tblUser user)
    {
       WriteDataContect.Attach
       (
          user,
          ReadDataContext.tblUsers
                         .Select(o => o.UserId == user.UserId)
       );
       WriteDataContext.SubmitChanges();
    }
