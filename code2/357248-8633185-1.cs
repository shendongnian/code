    public void UpdateUser(tblUser user)
    {
       WriteDataContect.Attach
       (
          user,
          ReadOnlyDataContext.tblUsers
                             .Select(o => o.UserId == user.UserId)
       );
       WriteDataContext.SubmitChanges();
    }
