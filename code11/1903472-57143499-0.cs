Try
{
  return Directory.GetAccessControl(@"D:\SaveTest")
    .Where(rule => (FileSystemRights.Write & rule.FileSystemRights) == FileSystemRights.Write)
    .Any(rule => rule.AccessControlType == AccessControlType.Allow);
} catch()
{
  return false;
}
