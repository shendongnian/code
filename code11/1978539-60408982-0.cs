    protected override void OnInit(EventArgs e)
    {
       base.OnInit(e);
       if (!Request.IsAuthenticated)
       {
          FormsAuthentication.RedirectToLoginPage();
          HttpContext.Current.ApplicationInstance.CompleteRequest();
       }
    }
