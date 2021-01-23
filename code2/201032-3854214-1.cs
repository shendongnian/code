    public class Admin : User
    {
      public Admin(int id)
        :base(id)
      {
        if(IsGuest)
          throw new SecurityException("Guest users cannot be admins.");
      }
    }
