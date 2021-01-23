    ProcessStartInfo psi = new ProcessStartInfo(myPath);
    psi.UserName = username;
    
    SecureString ss = new SecureString();
    foreach (char c in password)
    {
     ss.AppendChar(c);
    }
    
    psi.Password = ss;
    psi.UseShellExecute = false;
    Process.Start(psi);
