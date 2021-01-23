    public static MvcHtmlString GetDisplayNameSingleton(this HtmlHelper htmlHelper, string samAccountName)
    {
      var userRepository = DependencyResolver.Current.GetService<IUserRepository>();
      return new MvcHtmlString(userRepository != null ? userRepository.FindByUsername(samAccountName).DisplayName : "Ukjent");
    }
