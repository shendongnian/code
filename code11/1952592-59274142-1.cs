var methods = new List<AuthenticationMethod>();
if (!string.IsNullOrEmpty(settings.PrivateKeyPath))
{
    var keyFiles = new[] { new PrivateKeyFile(settings.PrivateKeyPath) };
    methods.Add(new PrivateKeyAuthenticationMethod(settings.UserName, keyFiles));
}
methods.Add(new PasswordAuthenticationMethod(settings.UserName, settings.UserPassword));
var connectionInfo =
    new ConnectionInfo(settings.Host, settings.Port, settings.UserName, methods.ToArray());
using (SftpClient sftpClient = new SftpClient(connectionInfo))
{
    // ...
}
