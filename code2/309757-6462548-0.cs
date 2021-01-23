    string cmdPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.System),
        "cmd.exe");
    string workingDirectory = @"C:\users\public";
    string pathToFile = Path.Combine(workingDirectory, "somefile.png");
    string arguments = string.Format("/c start {0}", pathToFile);
    var password = new SecureString();
    foreach (char c in "usersPassword")
        password.AppendChar(c);
    var processStartInfo = new ProcessStartInfo()
    {
        FileName = cmdPath,
        Arguments = arguments,
        WorkingDirectory = workingDirectory,
        UserName = "TestUser",
        Domain = Environment.MachineName, // Could use domain
        Password = password,
        UseShellExecute = false,
    };
    Process.Start(processStartInfo);
