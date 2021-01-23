    function SecureString MakeSecureString(string text)
    {
      SecureString secure = new SecureString();
      foreach (char c in text)
      {
        secure.AppendChar(c);
      }
     
      return secure;
    }
     
    function void RunAs(string path, string username, string password)
    {
      ProcessStartInfo myProcess = new ProcessStartInfo(path);
      myProcess.UserName = username;
      myProcess.Password = MakeSecureString(password);
      myProcess.UseShellExecute = false;
      Process.Start(myProcess);
    }
     
    RunAs(APPLICATION, USERNAME, PASSWORD);
