     if (!Request.IsAuthenticated)
      {
        HttpCookie ck = Request.Cookies[FormsAuthentication.FormsCookieName];
        if (ck != null)
        {
          FormsAuthenticationTicket oldTicket = FormsAuthentication.Decrypt(ck.Value);
          UserManagementUtils.RenewFormsAuthenticationTicket(Response, oldTicket);
        }
      }
