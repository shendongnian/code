using Microsoft.Deployment.WindowsInstaller;
using Microsoft.Win32;
namespace WixCustomAction
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CheckDotNetCore31Installed(Session session)
        {
            session.Log("Begin CheckDotNetCore31Installed");
            RegistryKey localMachine64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey lKey = localMachine64.OpenSubKey(@"SOFTWARE\dotnet\Setup\InstalledVersions\x64\sharedhost\", false);
            var version = (string)lKey.GetValue("Version");
            session["DOTNETCORE1"] = version == "3.1.0-preview3.19553.2" ? "1" : "0";
            return ActionResult.Success;
        }
    }
}
  [1]: https://stackoverflow.com/users/129130/stein-%C3%85smul
