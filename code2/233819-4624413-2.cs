    System.Diagnostics.Process proc = new System.Diagnostics.Process();
    System.Security.SecureString ssPwd = new System.Security.SecureString();
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.FileName = "filename";
    proc.StartInfo.Arguments = "args...";
    proc.StartInfo.Domain = "domainname";
    proc.StartInfo.UserName = "username";
    string password = "user entered password";
    for (int x = 0; x < password.Length; x++)
    {
        ssPwd.AppendChar(password[x]);
    }
    passowrd = "";
    proc.StartInfo.Password = ssPwd;
    proc.Start();
