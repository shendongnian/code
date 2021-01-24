public void ControlService(string host, string username, string password, string name, string action)
{
    var credentials = new UserCredentials(username, password);
    Impersonation.RunAsUser(credentials, SimpleImpersonation.LogonType.Interactive, () =>
    {
        ServiceControllerPermission scp = new ServiceControllerPermission(ServiceControllerPermissionAccess.Control, host, name);
        scp.Assert();
        ServiceController sc = new ServiceController(name, host);
        TimeSpan timeout = new TimeSpan(0,0,30);
        switch (action)
        {
            case "start":
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running, timeout);
                break;
            case "stop":
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                break;
            default:
                string msg = String.Format("Unknown action: '{0}'", action);
                throw new Exception(msg);
        }
    });
}
