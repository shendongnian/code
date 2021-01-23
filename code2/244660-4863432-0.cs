    public override void Install(IDictionary stateSaver)
    {
      string userName = this.Context.Parameters["username"];
      if (userName == null)
      {
        Console.WriteLine(s_usage);
        throw new InstallException("Missing parameter 'username'");
      }
    
      string userPass = this.Context.Parameters["password"];
      if (userPass == null)
      {
        Console.WriteLine(s_usage);
        throw new InstallException("Missing parameter 'password'");
      }
    
      m_serviceProcessInstaller.Username = userName;
      m_serviceProcessInstaller.Password = userPass;
    
      var path = new StringBuilder(Context.Parameters["assemblypath"]);
      if (path[0] != '"')
      {
        path.Insert(0, '"');
        path.Append('"');
      }
      path.Append(" --service");
      Context.Parameters["assemblypath"] = path.ToString();
      base.Install(stateSaver);
    }
