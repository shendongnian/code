    string pass = "yourpass";
    string name ="login";
    SecureString str;
    ProcessStartInfo startInfo = new ProcessStartInfo();
    char[] chArray = pass.ToCharArray();
    fixed (char* chRef = chArray)
    {
        str = new SecureString(chRef, chArray.Length);
    }
    startInfo.Password = str;
    startInfo.UserName = name;
    Process.Start(startInfo);
