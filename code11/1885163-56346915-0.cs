RegistryKey key = null;
try
{
  key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\JavaSoft\\Java Runtime Environment\\");
  if (key != null)
  {
    return true;
  }
}
finally
{
  if (key != null)
  {
    key.Dispose();
  }
}
