    public ActionResult Login(int pageId) {
      ViewData["ReturnUrl"] = Request["ReturnUrl"];
      return View(Cms3Configuration.DefaultViewModelWithPage(attachedPage));
    }
        
    public ActionResult Process(int pageId, string login, string password, string ReturnUrl) {
      var user = userRepository.GetByUserName(login);
      ViewData["ReturnUrl"] = ReturnUrl;
      if (user != null && authenticator.VerifyAccount(user, password)) {
        authenticator.SignIn(user);
        if (ReturnUrl.IsNotEmpty()) {
          return Redirect(ReturnUrl);
        }
        return Redirect("~" + attachedPage.Parent.Url);
      }
      ////login failed
      TempData[TempDataKeys.Error] = "Invalid login";
      return RedirectToAction("Login", new { pageId = pageId, ReturnUrl });
    }
        
    public ActionResult Logout(int pageId) {
      authenticator.SignOut();
      return RedirectToAction<LoginController>(x => x.Login(pageId), new {pageId = pageId});
    }
    
    public interface IAuthenticator {
      void SignIn(User person);
      IIdentity GetActiveIdentity();
      WindowsPrincipal GetActiveUser();
      void SignOut();
      bool VerifyAccount(User person, string password);
      bool HasRole(string person, string role);
    }
    
    public class Authenticator : IAuthenticator {
      private readonly IHttpContextProvider _httpContextProvider;
      private readonly ICryptographer _cryptographer;
      private readonly IRepository repository;
      
      public Authenticator(IHttpContextProvider httpContextProvider, ICryptographer cryptographer, IRepository repository) {
        _cryptographer = cryptographer;
        this.repository = repository;
        _httpContextProvider = httpContextProvider;
      }
    
      public void SignIn(User user) {
        FormsAuthentication.SignOut();
        if (user == null)
          return;
        DateTime issued = DateTime.Now;
        DateTime expires = issued.AddMinutes(30);
        if (user.ExpiryDate.HasValue) {
          if (user.Expires && expires > user.ExpiryDate)
            expires = (DateTime) user.ExpiryDate;
        }
        var roles = user.Roles.Select(x => x.Name).ToList();
        var ticket = new FormsAuthenticationTicket(1, user.UserName, issued, expires, false, string.Join(",", roles.Distinct().ToArray()));
        var encryptedTicket = FormsAuthentication.Encrypt(ticket);
        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket) { Expires = ticket.Expiration };
        _httpContextProvider.GetCurrentHttpContext().Response.Cookies.Add(authCookie);
      }
    
      public IIdentity GetActiveIdentity() {
        var httpcontext = _httpContextProvider.GetCurrentHttpContext();
        if (httpcontext == null || httpcontext.User == null)
          return null;
        return httpcontext.User.Identity;
      }
    
      public WindowsPrincipal GetActiveUser() {
        return _httpContextProvider.GetCurrentHttpContext().User as WindowsPrincipal;
      }
    
      public void SignOut() {
        FormsAuthentication.SignOut();
      }
    
      public bool VerifyAccount(User person, string password) {
        string passwordHash = _cryptographer.HashPassword(password, person.PasswordSalt);
        return passwordHash == person.Password && !person.HasExpired() && person.Approved == true;
      }
    
    }
    public interface IIdentitySession<T> {
      T GetLoggedInIdentity();
      bool IsAuthenticated { get; }
      bool IsAdministrator { get; }
    }
    public class IdentitySession<T> : IIdentitySession<T> where T : Identity {
      private readonly IAuthenticator<T> authenticator;
      private readonly IRepository repository;
      private readonly IHttpContextProvider httpContextProvider;
      private T currentIdentity;
      private static readonly object _lock = new object();
    
      public IdentitySession(IAuthenticator<T> authenticator, IRepository repository,
                             IHttpContextProvider httpContextProvider) {
        this.authenticator = authenticator;
        this.activeDirectoryMapper = activeDirectoryMapper;
        this.repository = repository;
        this.httpContextProvider = httpContextProvider;
      }
    
      public virtual T GetLoggedInIdentity() {
        IIdentity identity = authenticator.GetActiveIdentity();
    
        if (identity == null)
          return null;
    
        if (!identity.IsAuthenticated) 
          return null;
                    
        lock (_lock) {
          if (currentIdentity == null) {
            currentIdentity = repository.Query<T>().Where(x => x.UserName == identity.Name).FirstOrDefault();
          }
        }
       
        return currentIdentity;
      }
            
      public bool IsAuthenticated {
        get { return httpContextProvider.GetCurrentHttpContext().User.Identity.IsAuthenticated; }
      }
    
      public bool IsAdministrator {
        get { return false; }
      }
    }
    
