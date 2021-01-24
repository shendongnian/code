        SessionOptions sessionOptions = new SessionOptions
        {
            Protocol = Protocol.Sftp,
            HostName = "example.com",
            UserName = "username",
            SshHostKeyFingerprint = "ssh-rsa 2048 ...=",
            SshPrivateKeyPath = @"C:\some\path\key.ppk",
        };
        using (Session session = new Session())
        {
            session.Open(sessionOptions);
            // Your code
        }
    WinSCP needs the key converted to PPK format (You can use WinSCP GUI for that, or PuTTYgen). Also note that WinSCP verifies the SSH host key (`SshHostKeyFingerprint`). SSH.NET fails to do that by default, what is a security flaw.
    *(I'm the author of the library)*
