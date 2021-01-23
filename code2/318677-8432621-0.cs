    IISConfigurator Information: 0 : [00004816:00000004, 2011/12/08 13:01:51.971] Adding access to users IUSR and NT AUTHORITY\NETWORK SERVICE to path %MyPathOnTheBuildMachine%
    IISConfigurator Information: 0 : [00004816:00000004, 2011/12/08 13:01:51.972] Caught exception
    IISConfigurator Information: 0 : [00004816:00000004, 2011/12/08 13:01:51.974] Exception:System.InvalidOperationException: Method failed with unexpected error code 3.
    at System.Security.AccessControl.NativeObjectSecurity.CreateInternal(ResourceType resourceType, Boolean isContainer, String name, SafeHandle handle, AccessControlSections includeSections, Boolean createByName, ExceptionFromErrorCode exceptionFromErrorCode, Object exceptionContext)
    at System.Security.AccessControl.DirectorySecurity..ctor(String name, AccessControlSections includeSections)
    at System.IO.DirectoryInfo.GetAccessControl(AccessControlSections includeSections)
    at Microsoft.WindowsAzure.ServiceRuntime.IISConfigurator.FileManager.AddAllowAceIterative(DirectoryInfo dir, FileSystemRights rights, IdentityReference[] accounts)
    at Microsoft.WindowsAzure.ServiceRuntime.IISConfigurator.FileManager.AddAllowAce(DirectoryInfo dir, FileSystemRights rights, Boolean inherit, IdentityReference[] accounts)
    at Microsoft.WindowsAzure.ServiceRuntime.IISConfigurator.Security.AddAppPoolSidAceToVdir(String appPoolName, String sitePath, String appPoolSid)
    at Microsoft.WindowsAzure.ServiceRuntime.IISConfigurator.IISConfigurator.Deploy(String roleId, WebAppModel appModel, String roleRootDirectory, String sitesDestinationDirectory, String diagnosticsRootFolder, String roleGuid, Dictionary`2 globalEnvironment)
