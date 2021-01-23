    public ConnectionForm()
    {
      try
      {
        LocalControlUtil.Configure("ConnectionForm", "Username", usernameLabel);
        LocalControlUtil.Configure("ConnectionForm", "Password", passwordLabel);
        LocalControlUtil.Configure("ConnectionForm", "Domain", domainLabel);
        LocalControlUtil.Configure("ConnectionForm", "Cancel", cancelButton);
        LocalControlUtil.Configure("ConnectionForm", "OK", okButton);
      }
      catch
      {
        throw;
      }
    }
