SessionOptions sessionOptions = new SessionOptions
{
    Protocol = Protocol.Ftp,
    HostName = "ftp.example.com",
    UserName = "username",
    Password = "password",
    FtpSecure = FtpSecure.Implicit,
    TlsHostCertificateFingerprint = "xx:xx:xx:...",
};
using (Session session = new Session())
{
    session.Open(sessionOptions);
    session.PutFiles(localPath, remotePath).Check();
}
*(I'm the author of WinSCP)*
