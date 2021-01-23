    public override void Init()
          {
             this.PostAuthenticateRequest += new EventHandler(MvcApplication_PostAuthenticateRequest);
             base.Init();
          }
        
    void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
          {
              HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
              if (authCookie != null)
              {
                  string encTicket = authCookie.Value;
                     if (!String.IsNullOrEmpty(encTicket))
                     {
                            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(encTicket);
                            MyIdentity id = new MyIdentity(ticket.Name);
                            //HERE is where the magic happens!!
                            GenericPrincipal prin = new GenericPrincipal(id, id.Roles);
                            HttpContext.Current.User = prin;
                     }
               }
          }
