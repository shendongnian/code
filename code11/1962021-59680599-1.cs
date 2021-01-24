    public class UsersPage<USERS>:MyPageBase<USERS>{
    
      public void Index()
      {
         var filledData = Fill<USERS>();
      }
    }
    public class UsersPage<ORDERS >:MyPageBase<ORDERS >{
    
      public void Index()
      {
         var filledData = Fill<ORDERS>();
      }
    }
