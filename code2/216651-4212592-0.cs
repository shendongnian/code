if (Properties.Settings.Default.SrcPathList != null)
{
  SrcPathList = new List<string>(Properties.Settings.Default.SrcPathList.Cast<string>()); // From StringCollection to List<string>
}
else
{
  SrcPathList = new List<string>();
}
