string runtimeVersion = "2.0";
string frameworkPath;
RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\ASP.NET");
foreach (string childKeyName in regKey.GetSubKeyNames())
{
   if (Regex.IsMatch(childKeyName, runtimeVersion))
   {
       RegistryKey subKey = regKey.OpenSubKey(childKeyName))
       {
          frameworkPath = (string)subKey.GetValue("Path");
       }
   }
}
string machineConfigPath = Path.Combine(frameworkPath, @"config\machine.config");
string webRootConfigPath = Path.Combine(frameworkPath, @"config\web.config");
