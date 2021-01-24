    public static string GetUserName(IHttpContextAccessor httpContextAccessor)
    {
       string userName = string.Empty;
       if(httpContextAccessor != null &&
          httpContextAccessor.HttpContext != null &&
          httpContextAccessor.HttpContext.User != null &&
          httpContextAccessor.HttpContext.User.Identity != null)
          {
            userName = httpContextAccessor.HttpContext.User.Identity.Name;
            string[] usernames = userName.Split('\\');
            userName = usernames[1].ToUpper();
          }
          return userName;
    }
