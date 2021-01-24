Try
{
return System.IO.Directory.GetAccessControl(@"D:\SaveTest")
	    .GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount))
        .Cast<System.Security.AccessControl.FileSystemAccessRule>()
	    .Where(rule => (System.Security.AccessControl.FileSystemRights.Write & rule.FileSystemRights) == System.Security.AccessControl.FileSystemRights.Write)
	    .Any(rule => rule.AccessControlType == System.Security.AccessControl.AccessControlType.Allow);
} catch(Exception)
{
  return false;
}
