    public static class UserExtensions
    {
      public static string GetFullName(this User user)
      {
          return user.FirstName + " " + user.LastName;
      }
    }
    <%# Eval("User.FirstName") %>
    <%# Eval("User.LastName") %>
    <%# (Container.DataItem as User).GetFullName() %>
