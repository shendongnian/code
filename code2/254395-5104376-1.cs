    public static MvcHtmlString GetDisplayName(this HtmlHelper htmlHelper, string samAccountName)
    {
      if (HttpRuntime.Cache["UserRepository"] == null)
      {
        var newUserRepository = DependencyResolver.Current.GetService<IUserRepository>();
        HttpRuntime.Cache.Add("UserRepository", newUserRepository, null, DateTime.MaxValue,
                                      TimeSpan.FromMinutes(20), CacheItemPriority.Default, null);
      }
      var userRepository = HttpRuntime.Cache["UserRepository"] as IUserRepository;
      return new MvcHtmlString(userRepository != null ? userRepository.FindByUsername(samAccountName).DisplayName : "Ukjent");
    }
